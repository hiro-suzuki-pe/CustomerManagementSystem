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
      public vw_customer CustomerView { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CustomerView == null)
            {
                return NotFound();
            }

            var customerview = await _context.CustomerView.FirstOrDefaultAsync(m => m.Id == id);

            if (customerview == null)
            {
                return NotFound();
            }
            else 
            {
                CustomerView = customerview;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.CustomerView == null)
            {
                return NotFound();
            }
            var customerview = await _context.CustomerView.FindAsync(id);

            if (customerview != null)
            {
                CustomerView = customerview;
                _context.CustomerView.Remove(CustomerView);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
