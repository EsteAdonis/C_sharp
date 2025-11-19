using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C_Sharp.Services.ShoppingCart
{
	public class Product
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public decimal Price { get; set; }
	}

	public interface IProductRepository
	{
		Product GetById(int id);
	}

	public class ShoppingCart(IProductRepository productRepository)
  {
		private readonly IProductRepository productRepository = productRepository;
		private readonly Dictionary<int, int> items = [];

		public void AddItem(int productId, int quantity)
		{
			Product product = productRepository.GetById(productId);

			if (product != null)
			{
				if(items.ContainsKey(productId))
				{
					items[productId]+=quantity;
				}
				else 
				{
					items[productId]=quantity;
				}
			}
		}

		public void RemoveItem(int productId, int quantity)
		{
			if(items.ContainsKey(productId))
			{
				items[productId]-=quantity;
			}
			else
			{
				items.Remove(productId);
			}
		}

		public int GetItemCount() => items.Values.Sum();
  }
}