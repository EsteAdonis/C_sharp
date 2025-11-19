namespace C_Sharp.Models
{
	public class Book
	{
		public int Id { get; set; }
		public string? Title { get; set; }

		// Inverse Navigation Properties 
		// Fully Defined Relationship
	  public int AuthorId { get; set; }		
		public Author? Author {get; set;}
	}
}