
using C_Sharp.Strings;

namespace C_Sharp
{
	public sealed class Beast
	{
		public void Speak() => Console.WriteLine("The animal speaks.");
	}

	// This will cause a compile-time error
	// public class Dog : Animal 
	// {
	//     public void Bark()
	//     {
	//         Console.WriteLine("The dog barks.");
	//     }
	// }	

	public static class StringExtensions
	{
		public static string ReversString(this string value)
		{
			var reverse = new StringBuilder();
			for (int i = value.Length - 1; i >= 0; i--)
				reverse.Append(value[i]);
			return reverse.ToString();
		}
	}

	internal class Program
	{
		static void Main(string[] args)
		{

			StringHandling.MainExcuting();

			// Threading.StartCountDown();
			// Threading.ParallelForEachExample().GetAwaiter().GetResult();
			// Threading.SummonDogTasks().GetAwaiter().GetResult();	
			// Console.WriteLine("Press any key to exit...");
			// Console.ReadKey();


			// var myAnimal = new Beast();
			// myAnimal.Speak();

			// var reversString = "Eris Hermafrodita Atenea".ReversString();
			// Console.WriteLine(reversString);

			// object guy = "Timothy";
			// char[] letters = {'T','i','m','o','t','h','y'};
			// object myGuy = new string(letters);
			// object testGuy = "Timothy";
			// Console.WriteLine("Equals method result is {0} and == comprative result {1}", myGuy.Equals(guy), myGuy == guy);
			// Console.WriteLine("Equals method result is {0} and == comprative result {1}", myGuy.Equals(testGuy), guy == testGuy);

			// var Inheritance = new Inheritance(99, "Adonis");
			// Inheritance.InitOrders();
			// Inheritance.ListOrders();

			// TestingClasses.TestClass();
			// EntityFramework.EntityFrameworkExamples();
			// NavigationProperties.AddingAutorAndBooks();
			// RawSQL.RetieveFromSql();

			// StringRepeated.GetStringRepeted();
			// Dictionary.Dictionaryies();
			// Generics_Examples.Generics();
			// Tuples_Examples.Tuples();
			// Delegates_Example.Delegates();
			// LambdaExpression_Example.Lambda();
			// EventsAndDelegates_Example.Events();
			// ExtensionMethods_Example.Extensions();
			// Dynamic_Examples.Dynamics();

			// Overriding.ExecutingOverriding();
			// Interface_Testability.Test_OrderProcessor();
			// Interface_Extensibility.Run_Interface_Extensibility();
			// Stopwatch_Example.Running_Stopwatch();      

			// MultiThreading.MultiThreadingExamples();
			// Linq.LinqExamples();
			// await WorkingWithRepos.RunningRepo();
		}
	}
}








