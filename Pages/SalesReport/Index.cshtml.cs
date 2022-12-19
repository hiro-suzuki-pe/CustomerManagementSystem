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
    public class IndexModel : PageModel
    {
        private readonly CustomerManagementSystem.Models.MyContext _context;

        public IndexModel(CustomerManagementSystem.Models.MyContext context)
        {
            _context = context;
        }

        public IList<vw_salesReport> vw_salesReport { get;set; } = default!;

        public async Task OnGetAsync()
        {
            IQueryable<vw_salesReport> salesReportIQ = from s in _context.SalesReport select s;

            if (_context.SalesReport != null)
            {
                salesReportIQ = salesReportIQ.OrderBy(s => s.action_date);
                vw_salesReport = await salesReportIQ.AsNoTracking().ToListAsync();
            }
        }
    }
}
