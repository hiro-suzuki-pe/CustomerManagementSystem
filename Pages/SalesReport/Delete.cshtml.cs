using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CustomerManagementSystem.Models;

namespace CustomerManagementSystem.Pages.SalesReport
{
    public class DeleteModel : PageModel
    {
        private readonly CustomerManagementSystem.Models.MyContext _context;

        public DeleteModel(CustomerManagementSystem.Models.MyContext context)
        {
            _context = context;
        }

        [BindProperty]
      public vw_salesReport vw_salesReport { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SalesReport == null)
            {
                return NotFound();
            }

            var vw_salesreport = await _context.SalesReport.FirstOrDefaultAsync(m => m.Id == id);

            if (vw_salesreport == null)
            {
                return NotFound();
            }
            else 
            {
                vw_salesReport = vw_salesreport;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.SalesReport == null)
            {
                return NotFound();
            }
            var vw_salesreport = await _context.SalesReport.FindAsync(id);

            if (vw_salesreport != null)
            {
                vw_salesReport = vw_salesreport;
                _context.SalesReport.Remove(vw_salesReport);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
