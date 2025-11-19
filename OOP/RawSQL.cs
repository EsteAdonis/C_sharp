using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C_Sharp.Data;
using C_Sharp.Models;
using Microsoft.EntityFrameworkCore;

namespace C_Sharp
{
	public static class RawSQL
	{
		public static void RetieveFromSql()
		{
			// DbSet.FromSql
			// The FromSql method in Entity Framework Core allows you to execute a raw SQL query 
			// and map the results to entities. It's used to retrieve data from a database \
			// using custom SQL and map it directly to a type that represents the data.
			var context = new DataContext();			

			var authors = context
										.Authors
										.FromSql($"Select * From Authors Order by FirstName")
										.ToList();
										
			foreach(var auth in authors) {
				Console.WriteLine($"{auth.FirstName} - {auth.LastName}");
			}

			// DbSet.FromSql Parameterized Queries
			int index = 4;
			var authorSql = context
									    .Books
										  .FromSql($"Select * From Books Where Id = {index}")
 											.FirstOrDefault();
			Console.WriteLine($"{authorSql!.Title}");


			// DbSet.FromSql Stored Procedures
			var authorName = "Shakespeare";
			var books = context
								  .Books
    							.FromSql($"EXECUTE dbo.GetMostPopularBooks {authorName}")
    							.ToList();


			// var authorParams = new SqlParameter("author", "Homer");
			// var book2 = context	
			// 						.Books
			// 						.FromSql($"Execute dbo.GetMostPopularBooks {author}");

			// DbSet.FromSqlRaw
			var booksFromSelect = context
														.Books
														.FromSqlRaw($"Select * From Books")
														.ToList();
			var BookId = 5;
			    booksFromSelect = context
														.Books
														.FromSqlRaw($"Select * From Books Where id = {0}", BookId)
														.ToList();

			var authorId = 15;
			var sql = string.Format("SELECT * From Authors Where AuthorId = {0}", authorId);
			var author = context
									.Authors
									.FromSqlRaw(sql)
									.FirstOrDefault();

			// DbSet.FromSqlRaw Stored Procedures
			var bks = context.Books
        	  		.FromSqlRaw("EXEC GetAllBooks")
        				.ToList();

    	// var authId = new SqlParameter("@AuthorId", 1);
    	// var boks = context.Books
      // 	  			.FromSqlRaw("EXEC GetBooksByAuthor @AuthorId" , authId)
      //   				.ToList();

			// Non-Entity Types and Projections 
			var bksss = context
									.Books
        					.FromSql($"Select * From Books")
        					.Select(b => new { BookId = b.Id, Title = b.Title })
									.ToList();

			// If you're using interpolated strings, you should use FromSqlInterpolated instead, 
			// as it automatically parameterizes the query:
			var Homer = "Homer";
			var albums = context
									.Authors
									.FromSqlInterpolated($"Select * From Authors Where FirstName = {Homer}");			
		}

		public static void SqlQuery()
		{
			// the SqlQuery method that can execute raw SQL queries that return scalar or non-entity types.
			var context = new DataContext();

			var results = context
										.Database
										.SqlQuery<int>($"SELECT COUNT(*) FROM Books");

			var overAverageIds = context
													.Database
													.SqlQuery<int>($"SELECT [Id] AS [Value] FROM [Books]")
													.Where(id => id > context.Books.Average(b => b.Id))
													.ToList();										
		}

		public static void ExecuteSql()
		{
			// ExecuteSql. This method returns an integer specifying the number of rows affected 
			// by the SQL statement passed to it. Valid operations are INSERT, UPDATE, and DELETE. 
			// The method is not used for returning entities.
			var context = new DataContext();

			var affectedRows = context
												.Database
												.ExecuteSql($"UPDATE Authors SET FirstName='Julius' WHERE FirstName='Homer'");

			var name = "John";
			var newName = "Jane";
			    affectedRows = context
												.Database
												.ExecuteSql($"UPDATE Authors SET FirstName={newName} WHERE FirstName={name}");												
		}
		
	}
}