using System.Collections.Immutable;
using System.Data.Common;
using System.Threading.Tasks;
using C_Sharp.Data;
using C_Sharp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace C_Sharp
{
  public interface IAdonisRepo
  {
    DataContext _context { get; }

    Task<List<Author>> GetAuthors();
    Task<List<Customer>> GetCustomers();
  }

  public class AdonisRepo(DataContext context) : IAdonisRepo
  {
    public DataContext _context { get; } = context;

		public async Task<List<Models.Customer>> GetCustomers()
		{
			// Thread.Sleep(1000);
			return await _context.Customers.ToListAsync();
		}

    public async Task<List<Author>> GetAuthors()
    {
      // Thread.Sleep(1000);
      return await _context.Authors.ToListAsync();
    }
  }


  public static class EntityFramework
	{
		public static void EntityFrameworkExamples()
		{

			using DataContext context = new();

			// Retrieving a single object
			var s = context.Customers.First();  //Is similar to Top(1);
			Console.WriteLine($"{s}");

			var ss = context.Customers.FirstOrDefault();  //Is similar to Top(1);
			Console.WriteLine($"{ss}");

			// Returns the only element of a sequence, and throws an exception if there is not exactly one element in the sequence.
			var single = context.Customers.Where(c => c.Id == 9).Single();
			Console.WriteLine($"{single}");

			single = context.Customers.Single(c => c.Id == 9);
			Console.WriteLine($"{single}");


			// Note: The Find method is shorthand (syntactic sugar) for the SingleOrDefault method
			var customerByPrimaryKey = context.Customers.Find(888);
			Console.WriteLine($"{customerByPrimaryKey}");

			var allCustomers = context.Customers;
			foreach (var cust in allCustomers)
			{
				Console.WriteLine($"{cust.FirstName} - {cust.LastName}");
			}



			// Filtering and Ordering 
			var entity = context.Customers.FirstOrDefault(c => c.Id == 8);
			Console.WriteLine($"response State = {context.Entry(entity!).State}");
			entity!.FirstName = "Fergusson";
			Console.WriteLine($"response State = {context.Entry(entity!).State}");
			context.SaveChanges();
			Console.WriteLine($"response State = {context.Entry(entity!).State}");
			entity = context.Customers.FirstOrDefault(c => c.Id == 8);
			Console.WriteLine($"response State = {context.Entry(entity!).State}");
			Console.WriteLine($"{entity!.FirstName}");


			// Order by
			var products = context.Products.OrderBy(p => p.Name);
			var categories = context.OrderDetails.OrderBy(c => c.Product).OrderBy(c => c.ProductId);

			// Group by
			// var groups = context.Products.GroupBy(p => p.Name);
			// foreach(var group in groups)
			// {
			//     //group.Key is the CategoryId value
			//     foreach(var product in group)
			//     {
			//         // you can access individual product properties
			//     }
			// }

			// var groups2 = context.Products.GroupBy(p => new {Supplier = p.Id, Price = p.Price});
			// foreach(var group in groups)
			// {
			//     //group.Key.SupplierId is the SupplierId value
			//     //group.Key.Country is the CountryId value
			// }

			// // Returning non-entity types 
			// public class ProductHeader
			// {
			//     public int ProductId { get; set; }
			//     public string? ProductName { get; set; }
			// }

			// List<ProductHeader> headers = context.Products.Select(p => new ProductHeader{
			//     ProductId = p.ProductId,
			//     ProductName = p.ProductName
			// }).ToList();



			// Include related data 
			// var authors = context.Authors.Include(a => a.Books).ToList();

			// var authors = context.Authors
			//                     .Include(a => a.Biography)
			//                     .Include(a => a.Books)
			//                     .ToList();


			// NoTracking Queries
			// do not track changes in the context of the returned entities.
			// The use of NoTracking queries can result in better performance as it reduces the memory usage and overhead associated with tracking changes.
			var cars = context.Customers.AsNoTracking().ToList();

			// configure the tracking behavior at context-level instead of using the AsNoTracking method in each query:
			// using (var context = new SampleContext())
			// {
			//     context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
			//     var cars = context.Cars.ToList();
			//     var customers = context.Customers.ToList();
			//     ...
			// }


			// EF Core Like 
			// % (percentage sign): matches zero or more characters
			// _ (underscore): matches a single character
			var customers = context.Customers
											.Where(c => EF.Functions.Like(c.Address, "L%"))
											.ToList();

			Product veggieSpecial = new()
			{
				Name = "Veggie Special Pizza",
				Price = 9.99M
			};
			Console.WriteLine($"veggieSpecial State = {context.Entry(veggieSpecial).State}");
			context.Products.Add(veggieSpecial);


			Product deluxMeat = new()
			{
				Name = "Deluxe Meat Pizza",
				Price = 12.99M
			};

			context.SaveChanges();
			context.Products.Add(deluxMeat);


			// var products = new List<Product> {
			//     new() { Name = "Veggie-Special Pizza", Price = 9.99M },
			//     new() { Name = "Deluxe-Meat Pizza", Price = 12.99M },          
			// };
			// context.Products.AddRange(deluxMeat);
			// context.SaveChanges();      

			customers = new List<Models.Customer> {
				new() { FirstName="Adonis", LastName="Eris", Address="C. Obsidiana", Phone="555 555 555", Email="Julio@gmail"},
				new() { FirstName="Adonis", LastName="Eris", Address="C. Obsidiana", Phone="555 555 555", Email="Julio@gmail"},
				new() { FirstName="Adonis", LastName="Eris", Address="C. Obsidiana", Phone="555 555 555", Email="Julio@gmail"},
				new() { FirstName="Adonis", LastName="Eris", Address="C. Obsidiana", Phone="555 555 555", Email="Julio@gmail"},
			};

			var orders = new List<Order> {
				new() { CustomerId = 5, OrderPlaced = new DateTime(2025,02,14), OrderFulfilled=new DateTime(2025, 04,12) },
				new() { CustomerId = 6, OrderPlaced = new DateTime(2025,03,10), OrderFulfilled=new DateTime(2025, 04,12) },
				new() { CustomerId = 7, OrderPlaced = new DateTime(2025,04,08), OrderFulfilled=new DateTime(2025, 04,12) },
				new() { CustomerId = 9, OrderPlaced = new DateTime(2025,05,24), OrderFulfilled=new DateTime(2025, 04,12) }
			};

			var orderDetails = new List<OrderDetail> {
				new() { OrderId = 6, ProductId = 1, Quantity = 10 },
				new() { OrderId = 7, ProductId = 2, Quantity = 3  },
				new() { OrderId = 8, ProductId = 4, Quantity = 6 },
			};

			context.Customers.AddRange(customers);
			context.Orders.AddRange(orders);
			context.OrderDetails.AddRange(orderDetails);
			context.SaveChanges();


			var response = context.Products.OrderBy(p => p.Name).ToList();
			context.ChangeTracker.DetectChanges();
			Console.WriteLine($"DebugView.LongView = {context.ChangeTracker.DebugView.LongView}");
			Console.WriteLine($"response State = {context.Entry(response).State}");

			var entries = context.ChangeTracker.Entries();

			foreach (var entry in entries)
			{
				Console.WriteLine($"Entity: {entry.Entity.GetType().Name}, State: {entry.State}");
			}


			// ExecuteUpdateAsync and ExecuteDeleteAsync
			// ExecuteUpdateAsync allows you to update entities in the database without loading them into memory
			// var rowsAffected = await context.Teams.Where(x => x.Name == "Team A")	
			//                  	.ExecuteUpdateAsync(x => x.SetProperty(y => y.Name, "Team B"));

			// ExecuteDeleteAsync allows you to delete entities in the database without loading them into memory
			// This method is useful for bulk deletions where you don't need to load the entities
			// var rowsAffected = await context.Teams.Where(x => x.Name == "Team A")
			//                		.ExecuteDeleteAsync();

		}
	}
}