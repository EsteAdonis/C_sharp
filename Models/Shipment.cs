using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C_Sharp.Models
{
	public class Shipment
	{
		public int Id { get; set; }
		public float Cost { get; set; } = 0.0f;
		public DateTime	ShippingDate { get; set; }
	}
}