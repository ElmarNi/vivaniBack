using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VivaniBack.Models
{
    public class Contact
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

        [Required(ErrorMessage = "Əsas başlıq boş olmamalıdır")]
        public string MainHeader { get; set; }

        [Required(ErrorMessage = "Kiçik başlıq boş olmamalıdır")]
        public string SmallHeader { get; set; }


        [Required(ErrorMessage = "Email boş olmamalıdır"), EmailAddress(ErrorMessage = "E-mail düzgün daxil edilməmişdir"), DataType(DataType.EmailAddress, ErrorMessage = "E-mail düzgün daxil edilməmişdir")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Əlaqə nömrəsi boş olmamalıdır"), RegularExpression("^[0-9]*$", ErrorMessage = "Nömrəniz yalnız rəqəmlərdən ibarət olmalıdır")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Ünvan boş olmamalıdır")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "İş saatları boş olmamalıdır")]
        public string Hours { get; set; }
    }
}
