using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CustomerManagementSystem.Models;

namespace CustomerManagementSystem.Pages.Customer
{
    public class ListModel : PageModel
    {
        public IEnumerable<tbl_customer> Customer { get; set; }
        private readonly MyContext _context;

        public ListModel(MyContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            Customer = _context.Customer;
        }
    }
}
