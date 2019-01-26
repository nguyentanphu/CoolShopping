﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolShopping.Application.Entities
{
	public class OrderLine
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		//public IEnumerable<string> ProductAttributes { get; set; }
		public int Quantity { get; set; }
	}
}
