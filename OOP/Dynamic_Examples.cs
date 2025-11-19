using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C_Sharp.OOP
{
	public static class Dynamic_Examples
	{
		// dynamic is a type introduced in C# 4.0 that allows variables to bypass compile-time type checking 
		// and instead be resolved at runtime. This means that when you use dynamic, 
		// the type of the variable is determined dynamically, giving you more flexibility, 
		// but also less safety since errors might not be caught until runtime.

		// Key Characteristics of dynamic:
		//    Runtime Type Resolution: The compiler does not check the type at compile time, and members are resolved dynamically.
    //    Useful in Interoperability Scenarios: Such as working with COM objects, reflection, or dynamic languages like Python.
		//    Requires Caution: Because errors related to undefined members will only appear at runtime.

		public static void Dynamics()
		{
			dynamic value = 10;
			Console.WriteLine(value);  // Outputs: 10

			value = "Hello, world!";
			Console.WriteLine(value);  // Outputs: Hello, world!

			value = true;
			Console.WriteLine(value);  // Outputs: True
		}

		// Cautions When Using dynamic
		//    Performance Overhead: Runtime type resolution incurs some cost.
		//    Debugging Complexity: Errors show up at runtime instead of compile-time.
		//    Code Maintainability: Dynamic typing can make code harder to read and refactor.
	}
}