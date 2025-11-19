using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace C_Sharp
{
	public static class Stopwatch_Example
	{
		public static void Running_Stopwatch()
		{

			// Provides a set of methods and properties that you can use to accurately measure elapsed time.
			Stopwatch stopwatch = new();
			stopwatch.Start();
			Thread.Sleep(1000);
			stopwatch.Stop();

			// Get the elapsed time as a TimeSpan value.
			TimeSpan ts = stopwatch.Elapsed;

			// Format and display the TimeSpan value.
			string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds/10);
			Console.WriteLine($"Runtime: {elapsedTime}");
		}
	}
}