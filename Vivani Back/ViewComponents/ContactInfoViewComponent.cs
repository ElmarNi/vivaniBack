using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VivaniBack.DAL;

namespace VivaniBack.ViewComponents
{
    [ViewComponent(Name = "ContactInfo")]
    public class ContactInfoViewComponent : ViewComponent
    {
        private readonly VivaniDbContext _context;
        public ContactInfoViewComponent(VivaniDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Index", await _context.contact.FirstOrDefaultAsync());
        }
    }
}