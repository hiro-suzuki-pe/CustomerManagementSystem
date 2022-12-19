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
    public class DetailsModel : PageModel
    {
        private readonly CustomerManagementSystem.Models.MyContext _context;

        public DetailsModel(CustomerManagementSystem.Models.MyContext context)
        {
            _context = context;
        }

      public vw_salesReport vw_salesReport { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SalesReport == null)
            {
                return NotFound();
            }

            var vw_salesreportL = await _context.SalesReport.FirstOrDefaultAsync(m => m.Id == id);
            if (vw_salesreportL == null)
            {
                return NotFound();
            }
            else 
            {
                vw_salesReport = vw_salesreportL;
            }
            return Page();
        }
    }
}
