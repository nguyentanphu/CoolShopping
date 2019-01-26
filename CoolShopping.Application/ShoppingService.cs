using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolShopping.Application.Entities;
using CoolShopping.Application.Exceptions;
using CoolShopping.Application.Utils;

namespace CoolShopping.Application
{
	public class ShoppingService
	{
		public ShoppingService()
		{
			InitialShopService();
		}

		private void InitialShopService()
		{
			var supplier1 = new Supplier(1, "Chanel");
			Suppliers.Add(supplier1);

			var shirtCategory = new Category
			{
				CategoryId = 1,
				CategoryName = "Shirt",
				CategoryProperties = new List<CategoryProperty>
				{
					new CategoryProperty
					{
						CategoryPropertyName = "Size",
						CategoryPropertyValues = new List<string>
						{
							"M",
							"L",
							"XL",
							"XXL"
						}
					},
					new CategoryProperty
					{
						CategoryPropertyName = "Color",
						CategoryPropertyValues = new List<string>
						{
							"White",
							"Black"
						}
					}
				}
			};

			var tShirtCategory = new Category
			{
				CategoryId = 2,
				CategoryName = "TShirt",
				ParentCategoryId = 1,
				ParentCategory = shirtCategory
			};

			var dressShirtCategory = new Category
			{
				CategoryId = 3,
				CategoryName = "Dress shirt",
				ParentCategoryId = 1,
				ParentCategory = shirtCategory,
			};

			Categories.Add(shirtCategory);
			Categories.Add(tShirtCategory);
			Categories.Add(dressShirtCategory);

			var tShirt1 = new Product
			{
				ProductId = 1,
				ProductName = "TShirt black xl",
				Category = tShirtCategory,
				Supplier = supplier1,
				BuyPrice = 6,
				SellPrice = 12,
				ProductAttributes = new List<string> { "Black", "XL" },
				UnitsInStock = 0
			};
			var tShirt2 = new Product
			{
				ProductId = 2,
				ProductName = "TShirt special white M",
				Category = tShirtCategory,
				Supplier = supplier1,
				BuyPrice = 6,
				SellPrice = 12,
				ProductAttributes = new List<string> { "White", "M" },
				UnitsInStock = 20
			};

			var dress1 = new Product
			{
				ProductId = 3,
				ProductName = "Yellow dress shirt with diamond",
				Category = dressShirtCategory,
				Supplier = supplier1,
				BuyPrice = 8,
				SellPrice = 20,
				ProductAttributes = new List<string> { "Yellow", "M" },
				UnitsInStock = 30
			};

			var dress2 = new Product
			{
				ProductId = 4,
				ProductName = "Pink dress shirt with diamond",
				Category = dressShirtCategory,
				Supplier = supplier1,
				BuyPrice = 8,
				SellPrice = 20,
				ProductAttributes = new List<string> { "Pink", "L" },
				UnitsInStock = 40
			};

			Products.Add(tShirt1);
			Products.Add(tShirt2);
			Products.Add(dress1);
			Products.Add(dress2);
		}

		public ICollection<Product> Products { get; } = new List<Product>();
		public ICollection<Supplier> Suppliers { get; } = new List<Supplier>();

		public ICollection<Category> Categories { get; } = new List<Category>();

		public decimal TradeProduct(Order order, TradeMode tradeMode)
		{
			if (order == null) throw new ArgumentNullException(nameof(order));

			foreach (var orderLine in order.OrderLines)
			{
				var matchProduct = Products.First(p =>
					p.ProductName == orderLine.ProductName 
					/*&& orderLine.ProductAttributes.SequenceEqual(p.ProductAttributes)*/);

				if (tradeMode == TradeMode.Buy)
				{
					matchProduct.UnitsInStock += orderLine.Quantity;
					return matchProduct.BuyPrice * orderLine.Quantity * -1;
				}
				else
				{
					if (matchProduct.UnitsInStock < orderLine.Quantity)
						throw new OutOfStockException();

					matchProduct.UnitsInStock -= orderLine.Quantity;
					return matchProduct.SellPrice * orderLine.Quantity;
				}
			}

			return 0;
		}
		
	}
}
