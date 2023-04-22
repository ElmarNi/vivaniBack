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

        public virtual ProductCategory ProductCategory { get; set; }

        [Required(ErrorMessage = "Əyar seçin")]
        public int ProductTypeId { get; set; }

        public virtual ProductType ProductType { get; set; }

        public string MainImageUrl { get; set; }

		[NotMapped]
		public IFormFile MainImage { get; set; }

		[NotMapped]
		public ICollection<IFormFile> ProductImagesFile { get; set; }

		public virtual ICollection<ProductImage> ProductImages { get; set; }
	}
}

