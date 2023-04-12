using System;
using System.IO;
using System.Text;
using System.Net;
using System.Threading.Tasks;


namespace FetchingServer
{
	public class WebApiServer
	{
		public static HttpListener listener;
		public static string url = "http://10.150.0.38:8000/";
		public static int pageViews = 0;
		public static int requestCount = 0;
        public static string authKey = "OWY1MWQxNDcyYjk5OWUwYmE2NjViNTY1MTM2NDFjZGM=";

        public static async Task HandleIncomingConnections()
		{
			Helper.WriteLine("[WEBSERVER] Starting webserver...", ConsoleColor.DarkYellow);

			bool runServer = true;
            Helper.WriteLine("[WEBSERVER] Webserver is listening for requests...", ConsoleColor.DarkYellow);
            while (runServer)
			{
                HttpListenerContext context = await listener.GetContextAsync();

                Console.WriteLine("\n------ WEBSERVER REQUEST INFO START ------");
                Console.WriteLine("Accepted incoming request from " + context.Request.UserHostName + "");
                Console.WriteLine("Requested Endpoint: " + context.Request.UrlReferrer + "");
                Console.WriteLine("Total requests handled: " + requestCount);
                Console.WriteLine("------ WEBSERVER REQUEST INFO END ------\n");

                if ((context.Request.HttpMethod == "GET") && (context.Request.Url.AbsolutePath == "/version"))
                {
                    HandleVersion(context);
                }

                if ((context.Request.HttpMethod == "GET") && (context.Request.Url.AbsolutePath == "/"))
                {
                    HandleGetObject(context);

                }
            }
		}


        // This task handles the return of objects
        public static async Task HandleGetObject(HttpListenerContext context)
        {
            HttpListenerResponse response = context.Response;
            HttpListenerRequest request = context.Request;

            if (context.Request.QueryString["authKey"] != authKey)
            {
                byte[] data = Encoding.UTF8.GetBytes(String.Format("Forbidden"));

                response.StatusCode = 403;
                response.ContentType = "text/html";
                response.ContentEncoding = Encoding.UTF8;
                response.ContentLength64 = data.LongLength;

                await response.OutputStream.WriteAsync(data, 0, data.Length);
                response.Close();

            }


        }


        // This task handles the return of the version information
        public static async Task HandleVersion(HttpListenerContext context)
        {
            HttpListenerResponse response = context.Response;
            HttpListenerRequest request = context.Request;

            requestCount++;

            byte[] data = Encoding.UTF8.GetBytes(String.Format("<h2>Version 1.0</h2><small>Discovery Museum Collections Endpoint</small>"));
            response.ContentType = "text/html";
            response.ContentEncoding = Encoding.UTF8;
            response.ContentLength64 = data.LongLength;

            await response.OutputStream.WriteAsync(data, 0, data.Length);
            response.Close();

        }


		public WebApiServer()
		{
		}
	}
}

