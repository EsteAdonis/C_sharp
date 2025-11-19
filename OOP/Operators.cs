using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C_Sharp
{
	public static class Operators
	{
		public static void Operator()
		{
			object n1 = "Julio Esteban";
			object n2 = new string("Julio Esteban");
			Console.WriteLine("== operator result is {0}", n1 == n2);
			Console.WriteLine("== operator result is {0}", n1.Equals(n2));


			object name = "Timothy";
			char[] values = { 't', 'i', 'm', 'o', 't', 'h', 'y' };
			object myName = new string(values);
			Console.WriteLine("== operator result is {0}", name == myName);
			Console.WriteLine("Equals method result is {0}", myName.Equals(name));


			object guy = "Timothy";
			char[] letters = { 'T', 'i', 'm', 'o', 't', 'h', 'y' };
			object myGuy = new string(letters);
			Console.WriteLine("Equals method result is {0}", myGuy.Equals(name));
		}
	}
}