using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace VivaniBack.Models
{
	public class Product
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Ad boş ola bilməz")]
		public string Name { get; set; }

		public string Description { get; set; }

		[Required(ErrorMessage = "Qiymət boş ola bilməz")]
		public int Price { get; set; }

        public bool IsNew { get; set; }

		public bool IsBestSeller { get; set; }

		public bool IsTrendingProduct { get; set; }

		[DefaultValue(0)]
		public int? DiscountPercent { get; set; }

		[Required(ErrorMessage = "Kateqoriya seçin")]
		public int ProductCategoryId { get; set; }

        [NotMapped]
        public ProductCategory ProductCategory { get; set; }

		public string MainImageUrl { get; set; }

		[NotMapped]
		public IFormFile MainImage { get; set; }

		[NotMapped]
		public IEnumerable<IFormFile> ProductImagesFile { get; set; }

		[NotMapped]
		public IEnumerable<ProductImage> ProductImages { get; set; }

        [Required(ErrorMessage = "Əyar seçin")]
        public int ProductTypeId { get; set; }

        [NotMapped]
        public ProductType ProductType { get; set; }
	}
}

