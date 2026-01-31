
using System.ComponentModel;

namespace C_Sharp.OOP;


// Top-level the default is internal 
static class AccessModifier
{
	// static is private by default
	public static void MainClass()
	{
		Console.WriteLine("Balance = 60,000.00 MXN");


		var b = new Balance();
		Console.WriteLine($"GetBalance => {b.GetBalance()}");
		b.DoWork();
	}
}


// Default internal => public
interface IWorker {
  void DoWork(); // Default is public
}


// Default is internal 
class Balance : IWorker
{
	// Default is private 
	public void DoWork() => Console.WriteLine("");

	// Default is private 
	public double GetBalance() => 60000.0F;
}

