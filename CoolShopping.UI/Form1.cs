using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoolShopping.Application;
using CoolShopping.Application.Entities;
using CoolShopping.Application.Exceptions;
using CoolShopping.Application.Utils;

namespace CoolShopping.UI
{
	public partial class Form1 : Form
	{
		private decimal _fund = 100;
		private readonly ShoppingService _shoppingService;
		public Form1()
		{
			InitializeComponent();
			_shoppingService = new ShoppingService();


		}

		private void BuyButton_Click(object sender, EventArgs e)
		{
			var money = _shoppingService.TradeProduct(new Order { OrderLines = new List<OrderLine> { new OrderLine { Quantity = 1, ProductName = (string)Product.SelectedItem } } }, TradeMode.Buy);
			_fund += money;

			MessageBox.Show("Buy success!");
			FundValue.Text = _fund.ToString();

		}

		private void SellButton_Click(object sender, EventArgs e)
		{
			try
			{
				var money = _shoppingService.TradeProduct(new Order { OrderLines = new List<OrderLine> { new OrderLine { Quantity = 1, ProductName = (string)Product.SelectedItem } } }, TradeMode.Sell);
				_fund += money;

				MessageBox.Show("Sell success!");
				FundValue.Text = _fund.ToString();
			}
			catch (OutOfStockException outOfStockException)
			{
				MessageBox.Show("Out of stock", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
