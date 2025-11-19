using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace C_Sharp
{
	public static class MultiThreading
	{
		static int AddNumbers(int a, int b)
		{
			return a + b;
		}

		public static void MultiThreadingExamples() {

			Task task = new( ()=> 
			{
				Console.WriteLine("Running Task in separte thread ...");
				int result = AddNumbers(5, 10);
				Console.WriteLine("Result of addition: " + result);
			});
			task.Start();

		// Thread = an execution path of a program we can use multiple threads of perform
		//          different tasks of out program at the same timne.
		//          Current thread running is "main" thread
		//          using System.Threading;


		Thread mainThread = Thread.CurrentThread;
		Console.WriteLine($"MainThread {mainThread.Name}");

		mainThread.Name = "Adonis";
		Console.WriteLine($"MainThread {mainThread.Name}");

		Thread Thread1 = new(() => CountDown("Timer #1"));
		Thread Thread2 = new(() => CountUp("Timer #2"));
		Thread1.Start();
		Thread2.Start();

		// CountDown();
		// CountUp();

		Console.WriteLine($"{mainThread.Name} is complete" );
		// Console.ReadKey();

		}

		public static void CountDown(string name)
		{
			for(int i = 10; i >=0; i--) {
				Console.WriteLine("Timer #1: " + i + " seconds");
				Thread.Sleep(1000);
			}
			Console.WriteLine("Timer #1 is complete!");
		}

		public static void CountUp(string name)
		{
			for(int i = 0; i <=10; i++) {
				Console.WriteLine("Timer #2: " + i + " seconds");
				Thread.Sleep(1000);
			}
			Console.WriteLine("Timer #2 is complete!");
		}		


	}
}