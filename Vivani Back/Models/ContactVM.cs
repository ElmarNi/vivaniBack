using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VivaniBack.Models
{
    public class ContactVM
    {
        public IEnumerable<Contact> contact { get; set; }
        public ContactForm form { get; set; }
    }
}
