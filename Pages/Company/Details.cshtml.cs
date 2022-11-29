using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CustomerManagementSystem.Models;

namespace CustomerManagementSystem.Pages.Company
{
    public class DetailsModel : PageModel
    {
        private readonly CustomerManagementSystem.Models.MyContext _context;

        public DetailsModel(CustomerManagementSystem.Models.MyContext context)
        {
            _context = context;
        }

      public tbl_company tbl_company { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Company == null)
            {
                return NotFound();
            }

            var tbl_companyL = await _context.Company.FirstOrDefaultAsync(m => m.Id == id);
            if (tbl_companyL == null)
            {
                return NotFound();
            }
            else 
            {
                tbl_company = tbl_companyL;
            }
            return Page();
        }
    }
}
