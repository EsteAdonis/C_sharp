using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C_Sharp
{
	public static class Tuples_Examples
	{
		public static void Tuples()
		{
			// Tuples are a lightweight way to group multiple values together without defining 
			// a custom class or struct. 
			// They allow you to return multiple values from a method and work with related data conveniently.

			(double, int) t1 = (4.5, 3);
			Console.WriteLine($"Tuple with elements {t1.Item1} and {t1.Item2}.");

			(double Sum, int Count) = (4.5, 3);
			Console.WriteLine($"Sum of {Count} elements is {Sum}.");			

			(double, int) t = (4.5, 3);
			Console.WriteLine(t.ToString());
			Console.WriteLine($"Hash code of {t} is {t.GetHashCode()}.");		

			// Tuple Field names	
			var tt = (Sum: 4.5, Count: 3);
			Console.WriteLine($"Sum of {tt.Count} elements is {tt.Sum}.");

			(double Sum, int Count) d = (4.5, 3);
			Console.WriteLine($"Sum of {d.Count} elements is {d.Sum}.");			

			var sum = 4.5;
			var count = 3;
			var ttt = (sum, count);
			Console.WriteLine($"Sum of {ttt.count} elements is {ttt.sum}.");

			var a = 1;
			var s = (a, b: 2, 3);
			Console.WriteLine($"The 1st element is {s.Item1} (same as {s.a}).");
			Console.WriteLine($"The 2nd element is {s.Item2} (same as {s.b}).");
			Console.WriteLine($"The 3rd element is {s.Item3}.");

			// Tuple assignment and deconstruction
			(int, double) t11 = (17, 3.14);
			(double First, double Second) t2 = (0.0, 1.0);
			t2 = t11;
			Console.WriteLine($"{nameof(t2)}: {t2.First} and {t2.Second}");

			var tu = ("post office", 3.6);
			var (destination, distance) = tu;
			Console.WriteLine($"Distance to {destination} is {distance} kilometers.");

			// Tuple equality
			(int a, byte b) left = (5, 10);
			(long a, int b) right = (5, 10);
			Console.WriteLine(left == right);  // output: True
			Console.WriteLine(left != right);  // output: False

			var t111 = (A: 5, B: 10);
			var t222 = (B: 5, A: 10);
			Console.WriteLine(t111 == t222);  // output: True
			Console.WriteLine(t111 != t222);  // output: False			


			// Use cases of tuples
			// One of the most common use cases of tuples is as a method return type. 
			// That is, instead of defining out method parameters, you can group method results 
			// in a tuple return type, as the following example shows:

			(int min, int max) FindMinMax(int[] input)
			{
				if (input is null || input.Length == 0)
					throw new ArgumentException("Cannot find minimum and maximun of a null or empty array.");

				(int max, int min) = (int.MinValue, int.MaxValue);

				foreach(var i in input) {
					if (i < min)
						min = i;
					if (i > max)
						max = i;
				};

				return (min, max);
			};

			// First Example
			int[] xs = [4, 7, 9];
			var limits = FindMinMax(xs);
			Console.WriteLine($"Limits of [{string.Join(" ", xs)}] as {limits.min} and {limits.max}");

			int[] ys = [-9, 0, 67, 100];
			var (minimum, maximum) = FindMinMax(ys);
			Console.WriteLine($"Limits of [{string.Join(" ", ys)}] are {minimum} and {maximum}");
		}		
	}
}