using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VivaniBack.Models
{
    public class ContactForm
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad və Soyadınızı daxil edin"), MinLength(3, ErrorMessage = "Ad və soyad minimum 3 simvoldan ibarət olmalıdır")]
        public string Fullname { get; set; }

        [Required(ErrorMessage ="E-mailinizi daxil edin"), EmailAddress(ErrorMessage ="E-mail düzgün daxil edilməmişdir"),DataType(DataType.EmailAddress, ErrorMessage = "E-mail düzgün daxil edilməmişdir")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Nömrənizi daxil edin"), RegularExpression("^[0-9]*$", ErrorMessage = "Nömrəniz yalnız rəqəmlərdən ibarət olmalıdır")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Mesajınızı yazın")]
        public string Message { get; set; }

        public DateTime Date { get; set; }

        public bool IsResponsed { get; set; }
    }
}
