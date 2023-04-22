using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VivaniBack.Models
{
	public class ProductType
	{
		public int Id { get; set; }

        [Required(ErrorMessage = "Əyar boş ola bilməz")]
        public string Name { get; set; }

		public virtual ICollection<Product> Products { get; set; }
	}
}

