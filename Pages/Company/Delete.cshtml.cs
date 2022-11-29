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
    public class DeleteModel : PageModel
    {
        private readonly CustomerManagementSystem.Models.MyContext _context;

        public DeleteModel(CustomerManagementSystem.Models.MyContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Company == null)
            {
                return NotFound();
            }
            var tbl_companyL = await _context.Company.FindAsync(id);

            if (tbl_companyL != null)
            {
                tbl_company = tbl_companyL;
                _context.Company.Remove(tbl_company);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
