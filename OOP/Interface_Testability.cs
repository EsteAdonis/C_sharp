using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C_Sharp.Models;

namespace C_Sharp
{
	public interface IShippingCalculator
	{
		float CalculatorShipping(Order order);
	}

	public class ShippingCalculator: IShippingCalculator
	{
		public float CalculatorShipping(Order order)
		{
			if (order.TotalPrice < 30f)
				return order.TotalPrice * 0.1f;
			
			return 0;
		}
	}

	public class OrderProcessor(IShippingCalculator shippingCalculator)
  {
		private readonly IShippingCalculator _shippingCalculator = shippingCalculator;

    public void Process(Order order)
		{
			if (order.IsShipped)
				throw new InvalidOperationException("This order is already processed");
			
			order.Shipment = new Shipment
			{
				Cost = _shippingCalculator.CalculatorShipping(order),
				ShippingDate = DateTime.Today.AddDays(1)
			};
		}
	}

	public class Interface_Testability
	{
		public static void Test_OrderProcessor()
		{
			var orderProcess = new OrderProcessor(new ShippingCalculator());
			var order = new Order { Id=3, CustomerId=352, IsShipped=false, TotalPrice = 0, Customer = null, OrderDetails=null, OrderFulfilled= DateTime.Today.AddDays(5), OrderPlaced= DateTime.Today.AddDays(2), Shipment = new Shipment { Cost=30, ShippingDate = DateTime.Today.AddDays(15)} };
			orderProcess.Process(order);
		}
	}
}