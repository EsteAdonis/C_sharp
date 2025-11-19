using System.Diagnostics;

namespace C_Sharp.OOP;

public static class Threading
{
	public static void StartThread()
	{
		Thread thread = new(() => Console.WriteLine("Hello Adonis Estban Prometo Julio Dionisio"));
		thread.Start();
		Console.WriteLine("Thread started successfully.");
	}

	public async static Task PerformTask()
	{
		Task task = Task.Run(() => Console.WriteLine("Running in a Task!"));
		await task;
		Console.WriteLine("Back to main thread.");
	}

	public static async Task TaskWhenAll()
	{
		Task t1 = Task.Run(() => Console.WriteLine("Task 1"));
		Task t2 = Task.Run(() => Console.WriteLine("Task 2"));
		await Task.WhenAll(t1, t2);
		Console.WriteLine("Both tasks finished.");
	}

	public static async Task ParallelForEachExample()
	{
		var numbers = Enumerable.Range(1, 10);
		await Task.Run(() =>
		{
			Parallel.ForEach(numbers, number =>
			{
				Console.WriteLine($"Processing number: {number}");
			});
		});
		Console.WriteLine("Parallel processing completed.");
	}

	public static void StartCountDown()
	{
		// CountDown();
		// CountUp();
		Thread threadDown = new(() => CountDown("Dionisio"));
		Thread threadUp = new(() => CountUp("Prometeo"));
		threadDown.Start();
		threadUp.Start();
	}

	public static void CountDown(string name)
	{
		for (int i = 10; i >= 0; i--)
		{
			Console.WriteLine($"CountDown {name}: {i} seconds");
			Thread.Sleep(1000); // Sleep for 1 second	
		}
		Console.WriteLine("Countdown complete!");
	}

	public static void CountUp(string name)
	{
		for (int i = 0; i <= 10; i++)
		{
			Console.WriteLine($"CountUp {name}: {i} seconds");
			Thread.Sleep(1000); // Sleep for 1 second
		}
		Console.WriteLine("Count up complete!");
	}

	public static async Task ListTasks1()
	{
		var tasks = new List<Task>
		{
			Task.Run(() => Console.WriteLine("Task 1")),
			Task.Run(() => Console.WriteLine("Task 2")),
			Task.Run(() => Console.WriteLine("Task 3"))
		};

		await Task.WhenAll(tasks);
		Console.WriteLine("All tasks completed.");
	}

	public static async Task SummonDogTasks()
	{
		string Url = "https://raw.githubusercontent.com/l3oxer/Doggo/main/Readme.md";
				
		var tasks = new List<Task>
		{
			SummonDogLocally(), SummonDogFromUrl(Url),
		};

		Stopwatch sw = new();
		sw.Start();
		await Task.WhenAll(tasks);
		sw.Stop();

		Console.WriteLine($"All tasks completed in {sw.ElapsedMilliseconds} ms.");
	}

	public static async Task SummonDogLocally()
	{
		Console.WriteLine("1. Summoning Dog Locally...");
		// read all the text inside the dog.txt asynchronously
		string dogText = await File.ReadAllTextAsync("dog.txt");
		Thread.Sleep(1000);
		Console.WriteLine($"2. Dog Summoned Locally: \n{dogText}");
	}

	public static async Task SummonDogFromUrl(string url)
	{
		Console.WriteLine("1. Summoning Dog from URL...");
		using HttpClient client = new();
		string response = await client.GetStringAsync(url);
		Console.WriteLine($"2. Dog Summoned from URL: \n{response}");
	}

}
	