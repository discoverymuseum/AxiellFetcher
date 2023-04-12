using System;
using System.Net;
using FetchingServer.Objects;

namespace FetchingServer
{
	public class AdlibTestResponse
	{
		public int statusCode { get; set; }
	}

	public class ApiResponse
	{

		public string data { get; set; }
		public string url { get; set; }
		public int statusCode { get; set; }
	}

	public class AdlibHelper
	{
        static readonly HttpClient client = new HttpClient();

        public AdlibHelper()
		{

		}

		public static async Task<AdlibTestResponse> checkAdlibConnection()
		{
			AdlibTestResponse testresponse = new AdlibTestResponse();
			testresponse.statusCode = 0;

			try
			{
                Helper.WriteLine("[ADLIB] Performing test request over HTTPS...");
				using HttpResponseMessage response = await client.GetAsync("https://www.google.com");
				testresponse.statusCode = 200;
				response.EnsureSuccessStatusCode();
				string responseBody = await response.Content.ReadAsStringAsync();
			}
			catch(Exception e)
			{
				Helper.WriteLine("[ADLIB] Could not receive the test request.");
			
				testresponse.statusCode = 0;
			}

			return testresponse;

		}

		public static async Task<ApiResponse> DownloadFile(string query)
		{
			ApiResponse apiresponse = new ApiResponse();

            try
            {
                Helper.WriteLine("[ADLIB] Performing request to: " + Configuration.adlibEndpointUrl + query);
                using HttpResponseMessage response = await client.GetAsync(Configuration.adlibEndpointUrl + query);
                apiresponse.statusCode = 200;
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
				apiresponse.data = responseBody;
				apiresponse.url = query;
                Helper.WriteLine("[ADLIB] Data successfully received", ConsoleColor.Green);

				Converter.ConvertSingle(apiresponse);


            }
            catch(Exception e)
            {
                Helper.WriteLine("[ADLIB] Could not execute the request.", ConsoleColor.Red);
                Helper.WriteLine(e.Message);
                apiresponse.statusCode = 0;
            }

            return apiresponse;

        }

	}
}