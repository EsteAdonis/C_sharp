using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C_Sharp.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace C_Sharp
{
	public class LocalOrder(int id, int customerId, DateOnly orderDate, double amount)
  {
		public int Id => id;
		public int CustomerId => customerId;
		public DateOnly OrderDate => orderDate;
		public double Amount => amount;
  }

  public class MainClass(int id, string name, string otherParam)
  {
    public int Id => id;
    public string Name => name;
		protected List<LocalOrder> Orders = [];

		public void PrintUser() => Console.WriteLine($"{this.Id} - {this.Name}");

		protected void ListOrders() 
		{
			Console.WriteLine($"{otherParam}");
			foreach(var order in Orders) {
				Console.WriteLine($"#{order.Id}  CustomerId={order.CustomerId}  OrderDate={order.OrderDate}  Amount={order.Amount}");
			}
		}
  }

	public class Inheritance(int id, string name) : MainClass(id, name, "Order Value")
	{
    public new int Id = id;
    public new string Name = name;

		public void InitOrders()
		{
			base.Orders.Add(new LocalOrder(42, 890, new DateOnly(2025, 4, 12), 52234.34 ));
			base.Orders.Add(new LocalOrder(77, 25, new DateOnly(2025, 3, 27), 8923.59 ));		
			base.Orders.Add(new LocalOrder(21, 908, new DateOnly(2025, 3, 16), 1087.98 ));
			base.Orders.Add(new LocalOrder(21, 908, new DateOnly(2025, 3, 16), 1087.98 ));			
		}

		// The base keyword is used to access members of the base class from within a derived class. 
    public new void PrintUser()
		{
			base.PrintUser(); // calling the base class PrintUser method;
			Console.WriteLine($"{this.Id} - {this.Name}");
		}

		public new void ListOrders()
		{
			base.ListOrders();
		}

	}
}