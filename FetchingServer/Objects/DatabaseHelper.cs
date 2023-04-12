using System;
using MySqlConnector;

namespace FetchingServer.Objects
{
	public class DatabaseHelper
	{
		public static MySqlConnection connection;
		public static bool isConnected = false;
		public static DatabaseHelper instance;

		public DatabaseHelper()
		{
			instance = this;

			MySqlConnectionStringBuilder stringBuilder = new MySqlConnectionStringBuilder();
			stringBuilder.UserID = Configuration.mysqlDatabaseUsername;
			stringBuilder.Password = Configuration.mysqlDatabasePassword;
			stringBuilder.Server = Configuration.mysqlDatabaseHostname;
			stringBuilder.Database = Configuration.mysqlDatabaseDatabase;
            connection = new MySqlConnection(stringBuilder.ToString());

            connection.StateChange += Connection_StateChange;

			while (connection.State != System.Data.ConnectionState.Open)
			{
				try
				{
					connection.Open();
				}
				catch (Exception e)
				{
					Helper.WriteLine("[MariaDB] Exception occured while opening database connection.", ConsoleColor.Red);
					Helper.WriteLine("[MariaDB] " + e.Message, ConsoleColor.Red);

                    Helper.WriteLine("[MariaDB] Trying again in 5 seconds...");
                    Thread.Sleep(5000);

                }

			}

		}

		public static async Task<bool> getState()
		{

			return isConnected;
		}

        void Connection_StateChange(object sender, System.Data.StateChangeEventArgs e)
        {
			switch (e.CurrentState)
			{
				case System.Data.ConnectionState.Closed:
					DatabaseHelper.isConnected = false;
					Helper.WriteLine("[MariaDB] The database connection has been closed.", ConsoleColor.Blue);
					break;

				case System.Data.ConnectionState.Open:
					DatabaseHelper.isConnected = true;
                    Helper.WriteLine("[MariaDB] The database connection has been opened.", ConsoleColor.Green);

                    break;

				case System.Data.ConnectionState.Broken:
					DatabaseHelper.isConnected = false;
                    Helper.WriteLine("[MariaDB] The database connection has been broken.", ConsoleColor.Red);

                    break;

				case System.Data.ConnectionState.Connecting:
					DatabaseHelper.isConnected = false;
                    Helper.WriteLine("[MariaDB] Connecting to database...", ConsoleColor.Blue);

                    break;
				case System.Data.ConnectionState.Executing:
					DatabaseHelper.isConnected = true;
                    Helper.WriteLine("[MariaDB] Busy executing database command...", ConsoleColor.Yellow);

                    break;

				case System.Data.ConnectionState.Fetching:
					DatabaseHelper.isConnected = true;
                    Helper.WriteLine("[MariaDB] Busy fetching database data...", ConsoleColor.Yellow);

                    break;
			}
		
			
        }

       

		
	}
}

