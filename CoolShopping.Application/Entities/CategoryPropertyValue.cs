using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolShopping.Application.Entities
{
	public class CategoryPropertyValue
	{
		public CategoryPropertyValue(string categoryPropertyValueName)
		{
			CategoryPropertyValueName = categoryPropertyValueName;
		}

		public string CategoryPropertyValueName { get; set; }
	}
}
