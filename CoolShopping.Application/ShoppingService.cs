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

			var tShirt = new Product
			{
				ProductId = 1,
				ProductName = "TShirt polo special",
				Category = tShirtCategory,
				Supplier = supplier1,
				ProductVariants = new List<ProductVariant>
				{
					new ProductVariant
					{
						ProductVariantId = 1,
						ProductAttributes = new List<ProductAttribute>
						{
							new ProductAttribute
							{
								ProductAttributeName = "Size",
								ProductAttributeValue = "XL",
							},
							new ProductAttribute
							{
								ProductAttributeName = "Color",
								ProductAttributeValue = "Black"
							}
						},
						BuyPrice = 6,
						SellPrice = 12,
						UnitsInStock = 10
					
					},
					new ProductVariant
					{
						ProductVariantId = 2,
						ProductAttributes = new List<ProductAttribute>
						{
							new ProductAttribute
							{
								ProductAttributeName = "Size",
								ProductAttributeValue = "M",
							},
							new ProductAttribute
							{
								ProductAttributeName = "Color",
								ProductAttributeValue = "White"
							}
						},
						BuyPrice = 6,
						SellPrice = 12,
						UnitsInStock = 20

					}
				}
			};

			var dress = new Product
			{
				ProductId = 3,
				ProductName = "Yellow dress shirt with diamond",
				Category = dressShirtCategory,
				Supplier = supplier1,

				ProductVariants = new List<ProductVariant>
				{
					new ProductVariant
					{
						ProductVariantId = 3,
						ProductAttributes = new List<ProductAttribute>
						{
							new ProductAttribute
							{
								ProductAttributeName = "Size",
								ProductAttributeValue = "S",
							},
							new ProductAttribute
							{
								ProductAttributeName = "Color",
								ProductAttributeValue = "Pink"
							}
						},
						BuyPrice = 10,
						SellPrice = 20,
						UnitsInStock = 50

					},
					new ProductVariant
					{
						ProductVariantId = 4,
						ProductAttributes = new List<ProductAttribute>
						{
							new ProductAttribute
							{
								ProductAttributeName = "Size",
								ProductAttributeValue = "XS",
							},
							new ProductAttribute
							{
								ProductAttributeName = "Color",
								ProductAttributeValue = "Yellow"
							}
						},
						BuyPrice = 15,
						SellPrice = 30,
						UnitsInStock = 50

					}
				}
			};


			Products.Add(tShirt);
			Products.Add(dress);
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

				var matchVariant =
					matchProduct.ProductVariants.First(v => v.ProductVariantId == orderLine.ProductVariantId);

				if (tradeMode == TradeMode.Buy)
				{
					matchProduct.UnitsInStock += orderLine.Quantity;
					return matchVariant.BuyPrice * orderLine.Quantity * -1;
				}
				else
				{
					if (matchProduct.UnitsInStock < orderLine.Quantity)
						throw new OutOfStockException();

					matchProduct.UnitsInStock -= orderLine.Quantity;
					return matchVariant.SellPrice * orderLine.Quantity;
				}
			}

			return 0;
		}
		
	}
}
