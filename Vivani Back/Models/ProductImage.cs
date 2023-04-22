using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace VivaniBack.Models
{
	public class ProductImage
	{
		public int Id { get; set; }

		public int ProductId { get; set; }

		public virtual Product Product { get; set; }

		public string ImageUrl { get; set; }

		[NotMapped]
		public IFormFile Image { get; set; }
	}
}

