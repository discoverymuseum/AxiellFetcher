﻿using System;

namespace FetchingServer.Objects
{
	public class Configuration
	{
		public static string adlibEndpointUrl = "https://dcc-col.adlibhosting.com/wwwopacx/wwwopac.ashx";
		public static string mysqlDatabaseHostname = "92.222.202.163";
		public static string mysqlDatabaseUsername = "ginoferri";
		public static string mysqlDatabasePassword = "Ginof12!@";
		public static string mysqlDatabaseDatabase = "collection";
		public static string adlibImageDatabaseUrl = "https://dcc-col.adlibhosting.com/wwwopacx/wwwopac.ashx?command=getcontent&server=media&value=";
		public static string logLocation = @"C:\AxiellOutput\err.txt";


        public static int appManagedThreadId = 0;

		public Configuration()
		{

		}

		public Configuration(string adlibEndpointUrl = "")
		{

		}

		public Configuration(string adlibEndpointUrl, string mysqlDatabaseHostname, string mysqlDatabaseUsername, string mysqlDatabasePassword, string mysqlDatabaseDatabase)
		{

		}


	}
}