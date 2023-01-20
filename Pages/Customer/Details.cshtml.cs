using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CustomerManagementSystem.Models;
using CustomerManagementSystem.Pages.SalesReport;

namespace CustomerManagementSystem.Pages.Customer
{
    public class DetailsModel : PageModel
    {
        private readonly CustomerManagementSystem.Models.MyContext _context;

        public DetailsModel(CustomerManagementSystem.Models.MyContext context)
        {
            _context = context;
        }

        public vw_customer vw_customer { get; set; }
        public IList<vw_salesReport> vw_salesReport { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Customer == null)
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

            vw_salesReport = await _context.SalesReport.ToListAsync();


            return Page();
        }
    }
}
