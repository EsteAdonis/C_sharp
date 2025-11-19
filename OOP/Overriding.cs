using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C_Sharp
{
		// seald class can be instantiated, example: var sea = new Payment();
		// but cannot be inherited.
		public sealed class Payment
		{
			public int TransactionId { get; set; }
			public DateTime Transact_Date { get; set; }
			public double Amount {get; set;}
		}

		// Abstract Class and Method
		// An abstract class serves as a base class but cannot be instantiated. 
		// It’s used when you want to provide a blueprint for other classes to inherit from. 
		// Abstract classes can contain both abstract methods (methods with no implementation) 
		// and non-abstract methods (methods with implementation). 
		// Abstract methods must be overridden by any non-abstract class that inherits 
		// the abstract class.

		// Abstract class
		public abstract class Animal
		{
				public abstract void Speak(); // Abstract method with no implementation
				public void Eat() // Non-abstract method
				{
						Console.WriteLine("Eating...");
				}
		}

		// Derived class
		public class Dog : Animal
		{
			public override void Speak() // Overriding the abstract method
			{
				Console.WriteLine("Woof!");
			}
		}


		// There is no such concept as a virtual class in C#	
		public class Shape
		{
			public int Width { get; set; }
			public int Heigth { get; set; }
			public int MyProperty { get; set; }

			// virtual methods allow derived classes to override them while also providing 
			// a default implementation in the base class. Virtual methods offer a way for 
			// derived classes to modify or extend the behavior of the base class.
			public virtual void Draw() { 
 				Console.WriteLine("Drawing a shape...");				
			}
		}

		public class Circle: Shape
		{
			public override void Draw()
			{
				// base.Draw();    <= We can avoid this base.Draw() because is empty.
				Console.WriteLine("Circle Read");
			}
		}

		public class Square: Shape
		{
    	public override void Draw()
			{
				// base.Draw();
				Console.WriteLine("Square Room");
			}
		}

		public class Triangle: Shape
		{
    public override void Draw()
			{
				Console.WriteLine("Bermudas Triangle");
			}
		}


    public static class Overriding
    {
			public static void ExecutingOverriding()
			{
				var transac = new Payment();

				var circle = new Circle();
				var square = new Square();
				var triangle = new Triangle();
				List<Shape> shapes = [circle, square, triangle];

				foreach(var shape in shapes) 
				{
					shape.Draw();
				}


				Console.WriteLine("\n Testing Abstract Class (method no implementation)");
				Animal myDog = new Dog();
        myDog.Speak(); // Output: Woof!
        myDog.Eat();   // Output: Eating...
			}
    }
}

// Key Differences Between Abstract and Virtual Methods
// Implementation:

//    Abstract methods provide no implementation and must be overridden.
//    Virtual methods have a default implementation but can be overridden.

// Usage:
//    Abstract classes are used for creating a blueprint.
//    Virtual methods provide flexibility for extending or modifying behavior.

// Instantiation:
//    Abstract classes cannot be instantiated.
//    Classes with virtual methods can be instantiated.