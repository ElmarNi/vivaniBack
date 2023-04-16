using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace VivaniBack.Models
{
	public class Product
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		public string Description { get; set; }

		public int Price { get; set; }

		public bool IsNew { get; set; }

		public int DiscountPercent { get; set; }

		public int ProductCategoryId { get; set; }

		public ProductCategory ProductCategory { get; set; }

		public string MainImageUrl { get; set; }

		public IFormFile MainImage { get; set; }

		public IEnumerable<ProductImage> ProductImages { get; set; }

		public int ProductTypeId { get; set; }

		public ProductType ProductType { get; set; }
	}
}

