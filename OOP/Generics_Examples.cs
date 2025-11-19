using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C_Sharp
{
	// Generics in C# allow you to define classes, interfaces, and methods with type parameters. 
	// This means you can write flexible, reusable code while maintaining type safety. 
	// Instead of specifying a concrete data type upfront (Por adelantado), generics let you use a placeholder for the type, 
	// which is determined at runtime.

	// Why Use Generics?
	//    Type Safety: Catch type errors at compile-time instead of runtime.
	//    Code Reusability: Write one generic method/class to handle multiple types.
	//    Performance: Avoid unnecessary boxing/unboxing when dealing with value types.

	// Generics: Instead of defining the type within the class
	//           You define the type that the class is going to process.

	public class BoxInt  // In This class the type is defined inside the class
	{
		private int _value;
		public int Add(int value) => _value = value;
		public int GetValue () => _value;
	}

	// On the classes type is defined as parameter
	// Example 1: Generic Class
	public class Box<T>
	{
		private T? _value;
		public void Add(T value) => _value = value;
		public T GetValue() => _value!;  // Is a shorthand of return _value; 
	}

	// Example 2: Generic Method
	public class Utility
	{
		public static void Display<T>(T item)
						=> Console.WriteLine($"Value: {item}");
	}	


  // Example 3: Generic Interface
  public interface IRepository<T>
	{
		void Save(T item);
	}

  public class DataRepository<T> : IRepository<T>
  {
    public void Save(T item) => Console.WriteLine($"Saveing {item}");
  }

  public class Generics_Examples
	{
		public static void Generics()
		{
			// A non-generic class
			BoxInt boxInt = new();
			boxInt.Add(99);
			Console.WriteLine($"{boxInt.GetValue()}");

			// Generic classess
			Box<int> intBox = new();
			intBox.Add(100);
			intBox.Add(200);
			Console.WriteLine($"{intBox.GetValue()}");

			Box<string> strBox = new();
			strBox.Add("Greetings Adonis");
			Console.WriteLine($"{strBox.GetValue()}");

			// Usage of the generic method
			Utility.Display(42); // Output: Value: 42
			Utility.Display("Generics are cool!"); // Output: Value: Generics are cool!			

			//Usage of the generic interaface
			IRepository<string> repo = new DataRepository<string>();
			repo.Save("C# Generics");

			// Generics make your code more scalable and adaptable without sacrificing type safety. 
		}
	}
}