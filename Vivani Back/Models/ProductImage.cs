using System;
using Microsoft.AspNetCore.Http;

namespace VivaniBack.Models
{
	public class ProductImage
	{
		public int Id { get; set; }

		public int ProductId { get; set; }

		public Product Product { get; set; }

		public string ImageUrl { get; set; }

		public IFormFile Image { get; set; }
	}
}

