using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VivaniBack.Models
{
	public class ProductCategory
	{
		public int Id { get; set; }

		public string Name { get; set; }

		[NotMapped]
		public IEnumerable<Product> Products { get; set; }
	}
}

