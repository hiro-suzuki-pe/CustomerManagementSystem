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

        public PaginatedList<vw_salesReport> vw_salesReport { get;set; }

        public async Task OnGetAsync(string fromDate, string toDate, int? pageIndex)
        {
            IQueryable<vw_salesReport> salesReportIQ = from s in _context.SalesReport select s;

            if (_context.SalesReport == null)
                return;

            DateTime dt1, dt2;
            if (DateTime.TryParse(fromDate, out dt1) && DateTime.TryParse(toDate, out dt2))
            {
                salesReportIQ =
                    salesReportIQ.Where(s => s.action_date >= dt1 && s.action_date <= dt2);
                pageIndex = 1;
            }
            else if (DateTime.TryParse(fromDate, out dt1))
            {
                salesReportIQ = salesReportIQ.Where(s => s.action_date >= dt1);
                pageIndex = 1;
            }
            else if (DateTime.TryParse(toDate, out dt2))
            {
                salesReportIQ = salesReportIQ.Where(s => s.action_date <= dt2);
                pageIndex = 1;
            }
            salesReportIQ = salesReportIQ.OrderBy(s => s.action_date);

            var pageSize = Configuration.GetValue("PageSize", 4);
            vw_salesReport = await PaginatedList<vw_salesReport>.CreateAsync(
                salesReportIQ.AsNoTracking(), pageIndex ?? 1, pageSize);


        }
    }
}
