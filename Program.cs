using C_Sharp.Strings;
using C_Sharp.OOP;
using System.Runtime.CompilerServices;
using C_Sharp.Pattern.Design.Singleton;


namespace C_Sharp
{

	sealed class Beast 
	{
		public void DoWork()
		{
			throw new NotImplementedException();
		}

		public void Speak() => Console.WriteLine("The animal speaks.");
	}
// traps
// shoots then back.
// gain.
// mistakes that loud singals for a giant bomber.
	// This will cause a compile-time error
	// public class Dog : Animal 
	// {
	//     public void Bark()
	//     {
	//         Console.WriteLine("The dog barks.");
	//     }
	// }	

	static class StringExtensions
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
			// AccessModifier.MainClass();
			
			// var reversString = "Eris Hermafrodita Atenea".ReversString();
			// Console.WriteLine(reversString);			

			// Threading.StartCountDown();
			// Threading.ParallelForEachExample().GetAwaiter().GetResult();
			// Threading.SummonDogTasks().GetAwaiter().GetResult();	
			// Console.WriteLine("Press any key to exit...");
			// Console.ReadKey();

			// var myAnimal = new Beast();
			// myAnimal.Speak();

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


			// Design Pattern
			EntrySingleton.ExecSingleton();
		}
	}
}








