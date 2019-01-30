using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolShopping.Application.Entities
{
	public class ProductVariant
	{
		public int ProductVariantId { get; set; }
		public int UnitsInStock { get; set; }
		public decimal BuyPrice { get; set; }
		public decimal SellPrice { get; set; }

		public IEnumerable<ProductAttribute> ProductAttributes = new List<ProductAttribute>();
	}
}
