namespace C_Sharp.Models
{
	public class Author
	{
		public int Id { get; set; }
		public string? FirstName { get; set; } 
		public string? LastName { get; set; }

		// Navigation Properties 
		// Creating relation one-to-may
		public ICollection<Book> Books { get; set; } = [];
	}
}


