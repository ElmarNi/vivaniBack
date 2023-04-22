using System;
using System.Collections.Generic;
using VivaniBack.Models;
namespace VivaniBack.ViewModels
{
	public class ProductsVm
	{
		public IEnumerable<ProductCategory> productCategories { get; set; }
		public IEnumerable<ProductType> productTypes { get; set; }
		public IEnumerable<Product> products { get; set; }
	}
}

