using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolShopping.Application.Entities
{
	public class CategoryProperty
	{
		public string CategoryPropertyName { get; set; }

		public IEnumerable<string> CategoryPropertyValues = new List<string>();
	}
}
