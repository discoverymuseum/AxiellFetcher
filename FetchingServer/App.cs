﻿using System;
using System.Threading;
using FetchingServer.Objects;
using Newtonsoft.Json;

namespace FetchingServer
{
	public class App
	{

		public static CollectionList collectionList;

		public App()
		{
			
            Helper.WriteLine("[APP] Creating app instance...");
            Thread appthread = new Thread(() => AppThread());
			Helper.WriteLine("[APP] Starting app instance thread...");
			appthread.Start();
		}

		public async void AppThread()
		{
			int threadId = Thread.CurrentThread.ManagedThreadId;
			Configuration.appManagedThreadId = threadId;

			Helper.WriteLine("[APP] Create empty collectionlist instance...");
			collectionList = new CollectionList();
			collectionList.collectionList = new List<CollectionObject>();

			Helper.WriteLine("[APP] App thread started with threadid " + threadId);
			Helper.WriteLine("[APP] Starting MariaDB connection...");
            DatabaseHelper data = new DatabaseHelper();
            Helper.WriteLine("[APP] Waiting until MariaDB connection is up...");
            bool isConnected = await DatabaseHelper.getState();

			if (isConnected == false)
			{
                Helper.WriteLine("[APP] MariaDB is not connected", ConsoleColor.Red);
			}
			else
			{
				Helper.WriteLine("[APP] MariaDB is connected", ConsoleColor.Green);
			}

            Helper.WriteLine("[APP] Connecting to Axiell Collections...");
			AdlibTestResponse test = await AdlibHelper.checkAdlibConnection();

			if (test.statusCode == 200)
			{
				Helper.WriteLine("[APP] Succesfully connected to Axiell", ConsoleColor.Green);
			}

			ApiResponse res = await AdlibHelper.DownloadFile("https://www.google.com");
            Helper.WriteLine("[APP] Startup Complete", ConsoleColor.Green);
			MainMenu();

        }

		public async void ObjectCount()
		{
			ApiResponse response = await AdlibHelper.DownloadFile("?database=collectie");
		}

		public async void FetchObjects(int id = 0, int min = 0, int max = 0)
		{
			if (id != 0 && min == 0 && max == 0)
			{
				ApiResponse response = await AdlibHelper.DownloadFile("?database=continium&search=priref="+ id +"");
				//Helper.WriteLine("Answer: " + response.data);
			}

			if (id == 0 && min != 0 && max != 0)
			{
				int count = min;

				while (count <= max)
				{
					Console.WriteLine("Download: {0}", count);
                    ApiResponse response = await AdlibHelper.DownloadFile("?database=continium&search=priref=" + count + "");
                   // Helper.WriteLine("Answer: " + response.url);
                    count++;
				}

			}
		}

		public static void ShowHelp()
		{
			Console.ForegroundColor = ConsoleColor.Yellow;

			Console.WriteLine("============ MENU ===========");
            Console.WriteLine("exit\t\t\t\tEnds the application");
            Console.WriteLine("help\t\t\t\tShows this help info");
            Console.WriteLine("objectcount\t\t\tShows total objects in Axiell");
            Console.WriteLine("transfer\t\t\tTransfer objects from Axiell to MariaDB");
            Console.WriteLine("transfer <startid> <endid>\tTransfer objects from Axiell to MariaDB");
			Console.ForegroundColor = ConsoleColor.White;
        }

        public async void MainMenu()
		{
			string cmd = "";
            while (cmd != "exit")
			{
                Console.Write("~ ");
				cmd = Console.ReadLine();

				if (cmd == "output")
				{

					Console.WriteLine("============ START JSON OUTPUT ============\n\n\n");
					string output = JsonConvert.SerializeObject(collectionList, Formatting.Indented);
					Console.WriteLine(output);
                    Console.WriteLine("\n\n\n============ END JSON OUTPUT ============");
                }

				if (cmd == "info")
				{
					ShowHelp();
				}
				if (cmd.Contains("t"))
				{
					string[] query = cmd.Split(' ');
					int parameterCount = query.Count();

					if (parameterCount == 1)
					{
						Console.WriteLine(">> This command requires at least 1 argument");
					}else if (parameterCount == 2)
					{
						int value = 0;
						int.TryParse(query[1], out value);

						if (value == 0)
						{
							Console.WriteLine("Null");
						}
						else
						{
                            Console.WriteLine(">> Starting transfer of object {0}", query[1]);
							FetchObjects(int.Parse(query[1].ToString()));
                        }
					}else if (parameterCount == 3)
					{
                        Console.WriteLine(">> Starting transfer of objects {0} to {1}", query[1], query[2]);
						FetchObjects(0, int.Parse(query[1].ToString()), int.Parse(query[2].ToString()));
                    }

				}

			}

		}
	}
}