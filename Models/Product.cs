using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C_Sharp.Models
{
	public class Product
	{
		public int Id { get; set; }		
		[Required]
		public string? Name { get; set; }
		[Column(TypeName = "decimal(6,2)")]
		public decimal Price { get; set; }
	}
}