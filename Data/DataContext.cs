
namespace C_Sharp.Data
{
	public class DataContext: DbContext
	{
		public DbSet<Customer> Customers {get; set;}
		public DbSet<Order> Orders {get; set;}
		public DbSet<Product> Products {get; set;}
		public DbSet<OrderDetail> OrderDetails {get; set;}


		// Navigation Properties 
		// Creating relation one-to-may
		public DbSet<Author> Authors { get; set; }
		public DbSet<Book> Books {get; set;}

		protected override void OnConfiguring(DbContextOptionsBuilder opt)
		{
			opt.UseSqlServer("Server=localhost;Database=Adonis;Trusted_Connection=True;TrustServerCertificate=True");
		}
	}
}