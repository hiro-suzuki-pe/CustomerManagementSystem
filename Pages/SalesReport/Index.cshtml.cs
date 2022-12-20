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
        private readonly IConfiguration Configuration;

        public IndexModel(CustomerManagementSystem.Models.MyContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public IList<vw_salesReport> vw_salesReport { get;set; } = default!;

        public async Task OnGetAsync(string fromDate, string toDate)
        {
            IQueryable<vw_salesReport> salesReportIQ = from s in _context.SalesReport select s;

            if (_context.SalesReport == null)
                return;

            DateTime dt1, dt2;
            if (DateTime.TryParse(fromDate, out dt1) && DateTime.TryParse(toDate, out dt2))
            {
                salesReportIQ =
                    salesReportIQ.Where(s => s.action_date >= dt1 && s.action_date <= dt2);
            }
            else if (DateTime.TryParse(fromDate, out dt1))
            {
                salesReportIQ =
                    salesReportIQ.Where(s => s.action_date >= dt1);
            }
            else if (DateTime.TryParse(toDate, out dt2))
            {
                salesReportIQ =
                    salesReportIQ.Where(s => s.action_date <= dt2);
            }
            salesReportIQ = salesReportIQ.OrderBy(s => s.action_date);
            vw_salesReport = await salesReportIQ.AsNoTracking().ToListAsync();
        }
    }
}
