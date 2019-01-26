using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolShopping.Application.Exceptions
{
	public class IncorrectPriceException : Exception
	{
		public IncorrectPriceException(Exception innerException = null) : base(
			"Buy price cannot be greater than sell price", innerException)
		{

		}
	}
}
