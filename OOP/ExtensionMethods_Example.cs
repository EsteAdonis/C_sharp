using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C_Sharp
{
	// Extension Methods in C# allow you to add new functionality to an existing class or struct 
	// without modifying its source code. They are static methods defined in static classes, 
	// and they enhance readability and reusability.

	// How Extension Methods Work
  //   The first parameter of an extension method must be preceded by the this keyword.
  //   This parameter specifies the type you are extending.
  //   They appear as if they are methods of the extended type, even though they are defined separately.

	public static class StrinExtensions
	{
		public static string ToFriendlyFormat(this string str) => $"🌟 {str} 🌟";
	}

	public static class ListExtensions
	{
		public static int SumEvenNumbers(this List<int> numbers) 
															=> numbers.Where(n => n % 2 == 0).Sum();
	}

	public static class ExtensionMethods_Example
	{
		public static void Extensions()
		{
			string myText = "Greetings Adonis Prometeo Eris Atenea";
			Console.WriteLine($"{myText.ToFriendlyFormat()}"); // Using the extensions


      // Example: Extending List<int> to Get the Sum of Even Numbers
      List<int> myNumbers = [1, 2, 3, 4, 5, 6, 7, 8, 9];
			Console.WriteLine($"Sum of even numbers: {myNumbers.SumEvenNumbers()}");
		}	
	}
}