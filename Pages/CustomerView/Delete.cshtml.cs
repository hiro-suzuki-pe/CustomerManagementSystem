using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CustomerManagementSystem.Models;

namespace CustomerManagementSystem.Pages.CustomerView
{
    public class DeleteModel : PageModel
    {
        private readonly CustomerManagementSystem.Models.MyContext _context;

        public DeleteModel(CustomerManagementSystem.Models.MyContext context)
        {
            _context = context;
        }

        [BindProperty]
      public vw_customer vw_customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CustomerView == null)
            {
                return NotFound();
            }

            var vw_customerL = await _context.CustomerView.FirstOrDefaultAsync(m => m.Id == id);

            if (vw_customerL == null)
            {
                return NotFound();
            }
            else 
            {
                vw_customer = vw_customerL;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.CustomerView == null)
            {
                return NotFound();
            }
            var vw_customerL = await _context.CustomerView.FindAsync(id);

            if (vw_customerL != null)
            {
                vw_customer = vw_customerL;
                _context.CustomerView.Remove(vw_customer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
