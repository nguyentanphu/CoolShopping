using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolShopping.Application.Exceptions
{
	public class OutOfStockException : Exception
	{
		public OutOfStockException() : base("Not enough stock")
		{
		}
	}
}
