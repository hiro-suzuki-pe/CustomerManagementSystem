using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CustomerManagementSystem.Models;

namespace CustomerManagementSystem.Pages.Customer
{
    public class DetailsModel : PageModel
    {
        private readonly CustomerManagementSystem.Models.MyContext _context;

        public DetailsModel(CustomerManagementSystem.Models.MyContext context)
        {
            _context = context;
        }

      public tbl_customer tbl_customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Customer == null)
            {
                return NotFound();
            }

            var tbl_customer = await _context.Customer.FirstOrDefaultAsync(m => m.Id == id);
            if (tbl_customer == null)
            {
                return NotFound();
            }
            else 
            {
                tbl_customer = tbl_customer;
            }
            return Page();
        }
    }
}
