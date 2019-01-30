using System.Collections.Generic;
using CoolShopping.Application.Exceptions;

namespace CoolShopping.Application.Entities
{
	public class Product
	{
		public Product()
		{

		}
		public Product(int productId, string productName, int unitsInStock, decimal buyPrice, decimal sellPrice, Category category, Supplier supplier)
		{
			ProductId = productId;
			ProductName = productName;
			Category = category;
			Supplier = supplier;

			if (buyPrice > sellPrice) throw new IncorrectPriceException();
		}

		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public IEnumerable<ProductVariant> ProductVariants = new List<ProductVariant>();
		public int? UnitsInStock { get; set; } = 0;
		public decimal? BuyPrice { get; set; }
		public decimal? SellPrice { get; set; }

		public Category Category { get; set; }

		public Supplier Supplier { get; set; }

	}
}
