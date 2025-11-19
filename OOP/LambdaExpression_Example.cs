using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;

namespace C_Sharp
{
	public class LambdaBook
	{
		public string? Title { get; set; }
		public float Price { get; set; }
	}

	public class BookRepository
	{
		public static List<LambdaBook> GetBooks()
		{
			return [
				new LambdaBook() {Title ="Adonis", Price=33.52F},
				new LambdaBook() {Title ="Prometeo", Price=41.25F},
				new LambdaBook() {Title ="Atenea Eris", Price=29.99F}								
			];
		}
	};

	public static class LambdaExpression_Example
	{
		// public static bool IsCheaperThan35Dollars(Book book) => book.Price < 35.00F;

		public static void Lambda()
		{
			Func<int, int> square = number => number * number;

			const int factor = 5;
			Func<int, int> multipler = n => n * factor;
      // static int multipler(int n) => n * factor;

      Console.WriteLine($"Square(5) = {square(5)}");
      Console.WriteLine($"Muliplier(5) = {multipler(5)}");			

			
			var books = BookRepository.GetBooks();
			var cheapBooks = books.FindAll(b => b.Price < 1.00F);
			Console.WriteLine($"Cheap Book: ${cheapBooks}");
		}
	}
}