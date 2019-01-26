﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolShopping.Application.Entities
{
	public class Supplier
	{
		public Supplier(int supplierId, string supplierName)
		{
			SupplierId = supplierId;
			SupplierName = supplierName;
		}

		public int SupplierId { get; set; }
		public string SupplierName { get; set; }
	}
}
