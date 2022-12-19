using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CustomerManagementSystem.Models;

namespace CustomerManagementSystem.Pages.SalesReport
{
    public class EditModel : PageModel
    {
        private readonly CustomerManagementSystem.Models.MyContext _context;

        public EditModel(CustomerManagementSystem.Models.MyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public vw_salesReport vw_salesReport { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SalesReport == null)
            {
                return NotFound();
            }

            var vw_salesreportL =  await _context.SalesReport.FirstOrDefaultAsync(m => m.Id == id);
            if (vw_salesreportL == null)
            {
                return NotFound();
            }
            vw_salesReport = vw_salesreportL;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(vw_salesReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vw_salesReportExists(vw_salesReport.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool vw_salesReportExists(int id)
        {
          return _context.SalesReport.Any(e => e.Id == id);
        }
    }
}
