namespace C_Sharp
{
	public static class Delegates_Example
	{
		// Delegates is a feature that allows you to pass methods as arguments to other methods. 
		// They are similar to function pointers in C++ but are type-safe.

		// a delegate is a type that represents references to methods with a 
		// specific parameter list and return type. 
		// Think of it as a function pointer that allows you to 
		// encapsulate a method and pass it around as an argument.

		// Why are delegtes useful?
		// Encapsulation: They allow methods to be treated as objects.
		// Callbacks: Perfect for scenarios where you need to call back a method dynamically.
		// Event Handling: The foundation for handling events in C#.
		// Extensibility: Helps in designing flexible and loosely coupled code.


		public class Button
		{
			public delegate void ClickHandler();
			public event ClickHandler? Click;
			public void Press() => Click?.Invoke();
		}

		delegate void MyDelegate(string message);
		delegate int MathOperation(int x, int y);

		public static void DisplayMessage(string msg)
									 					=> Console.WriteLine($"Message: {msg}");

		public static void Delegates()
		{
			// Basic Delegate Example:
			// Instantiate delegate with method reference or passing the method as a argument
			MyDelegate del = DisplayMessage;

			// Call the delegate
			del("Greetings Adonis Prometeo");

			// Using Delegates with Lambda Expressions:
			MathOperation add = (a, b) => a + b;
			MathOperation multiply = (a, b) => a * b;

			Console.WriteLine($"Sum: {add(5,3)}");
			Console.WriteLine($"Product: {multiply(5,3)}");

			// Delegates with Events:
			Button button = new();

			// Subscribe to the event
			button.Click += () => Console.WriteLine("Button clicked!");

			button.Press(); // Outpus: Button clicked!
		}
	}
}