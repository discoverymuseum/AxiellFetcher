using System;

	public class Helper
	{

		public static void WriteLine(string message)
		{
			Console.WriteLine("{0}: {1}", GetTime(), message);	
		}

		public static void WriteLine(string message, ConsoleColor color)
		{
			ConsoleColor colorBefore = Console.ForegroundColor;
			Console.ForegroundColor = color;
            Console.WriteLine("{0}: {1}", GetTime(), message);
			Console.ForegroundColor = colorBefore;
        }

        public static void WriteLine(string message, bool ShowTimestamp)
        {
            if (ShowTimestamp)
            {
           
                Console.WriteLine("{1}", message);
          
            }
        }

        public static void WriteLine(string message, ConsoleColor color, bool ShowTimestamp)
		{
			if (ShowTimestamp)
			{
				ConsoleColor colorBefore = Console.ForegroundColor;
				Console.ForegroundColor = color;
				Console.WriteLine("{1}", message);
				Console.ForegroundColor = colorBefore;
			}
        }

		static private string GetTime()
		{
			DateTimeOffset time = DateTimeOffset.Now;
			
			string consoleTimestamp = string.Format("[{0}/{1} {2}:{3}:{4}]", time.Day, time.Month, time.Hour, time.Minute, time.Second);
			return consoleTimestamp;
			
		}

}


