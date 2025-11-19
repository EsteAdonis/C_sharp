using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace C_Sharp.OOP
{
	public class LocalOrder(int id, int customerId, DateOnly orderDate, double amount)
  {
		public int Id => id;
		public int CustomerId => customerId;
		public DateOnly OrderDate => orderDate;
		public double Amount => amount;
  }


  public class Customers(int id, string name, DateOnly birthDate)
  {
    public int Id => id;
    public string Name  => name;
    public DateOnly BirthDate  => birthDate;

		protected List<LocalOrder> Orders = [];

		public void ListOrders() 
		{
			foreach(var order in Orders) {
				Console.WriteLine($"#{order.Id}  CustomerId={order.CustomerId}  OrderDate={order.OrderDate}  Amount={order.Amount}");
			}
		}				

		public void InitOrders()
		{
			Orders.Add(new LocalOrder(42, 890, new DateOnly(2025, 4, 12), 52234.34 ));
			Orders.Add(new LocalOrder(77, 25, new DateOnly(2025, 3, 27), 8923.59 ));		
			Orders.Add(new LocalOrder(21, 908, new DateOnly(2025, 3, 16), 1087.98 ));
			Orders.Add(new LocalOrder(21, 908, new DateOnly(2025, 3, 16), 1087.98 ));			
		}
  }

	public class TestingClasses()
	{
		public static void TestClass()
		{
			var custom = new Customers(99, "Adonis", new DateOnly(1964, 4, 12));
		}
	}
}