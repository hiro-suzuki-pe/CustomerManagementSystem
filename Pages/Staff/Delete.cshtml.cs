using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CustomerManagementSystem.Models;

namespace CustomerManagementSystem.Pages.Staff
{
    public class DeleteModel : PageModel
    {
        private readonly CustomerManagementSystem.Models.MyContext _context;

        public DeleteModel(CustomerManagementSystem.Models.MyContext context)
        {
            _context = context;
        }

        [BindProperty]
      public tbl_staff tbl_staff { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Staff == null)
            {
                return NotFound();
            }

            var tbl_staffL = await _context.Staff.FirstOrDefaultAsync(m => m.Id == id);

            if (tbl_staffL == null)
            {
                return NotFound();
            }
            else 
            {
                tbl_staff = tbl_staffL;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Staff == null)
            {
                return NotFound();
            }
            var tbl_staff = await _context.Staff.FindAsync(id);

            if (tbl_staff != null)
            {
                tbl_staff = tbl_staff;
                _context.Staff.Remove(tbl_staff);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
