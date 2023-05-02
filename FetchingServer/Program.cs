using System;
using FetchingServer.Objects;
using FetchingServer;

namespace FetchingServer
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("####################################");
            Console.WriteLine("##                                ##");
            Console.WriteLine("##    Discovery Museum            ##");
            Console.WriteLine("##    Collection Fetching Server  ##");
            Console.WriteLine("##    v1.1                        ##");
            Console.WriteLine("##                                ##");
            Console.WriteLine("####################################\n\n");


            //WebApiServer.listener = new System.Net.HttpListener();
            //WebApiServer.listener.Prefixes.Add("http://10.150.0.120:8005/");
            //WebApiServer.listener.Prefixes.Add("http://127.0.0.1:8005/");
            //WebApiServer.listener.Prefixes.Add("http://localhost:8005/");


            //WebApiServer.listener.Start();

            Startup();

        }

        static void Startup()
        {
            //Task listenTask = WebApiServer.HandleIncomingConnections();
            App app = new App();
            app.MainMenu();
           


        }


    }
}