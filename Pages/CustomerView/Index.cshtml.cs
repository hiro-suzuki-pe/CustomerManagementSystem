using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CustomerManagementSystem.Models;
using Microsoft.Data.SqlClient;

namespace CustomerManagementSystem.Pages.CustomerView
{
    public class IndexModel : PageModel
    {
        private readonly CustomerManagementSystem.Models.MyContext _context;

        public IndexModel(CustomerManagementSystem.Models.MyContext context)
        {
            _context = context;
        }

        public string CustomerNameSort { get; set; }
        public string CustomerKanaSort { get; set; }
        public string CompanyNameSort { get; set; }
        public string CompanyKanaSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<vw_customer> vw_customer { get;set; } = default!;

        public async Task OnGetAsync(string sortOrder)
        {
            if (_context.CustomerView != null)
            {
                // using system ;
                // CustomerNameSort = String.IsNullOrEmpty(sortOrder) ? "customer_kana_desc" : "";
                // CustomerKanaSort = String.IsNullOrEmpty(sortOrder) ? "customer_kana_desc" : "";
                // CompanyNameSort = String.IsNullOrEmpty(sortOrder) ? "Company_kana_desc" : "";
                // CompanyKanaSort = String.IsNullOrEmpty(sortOrder) ? "Company_kana_desc" : "";

                IQueryable<vw_customer> CustomerViewIQ = from s in _context.CustomerView select s;
                switch (sortOrder)
                {
                    //   case "customer_kana_desc":
                    case "CustomerNameSort":
                        CustomerViewIQ = CustomerViewIQ.OrderBy(s => s.customer_kana);
                        break;
                    case "CompanyNameSort":
                        CustomerViewIQ = CustomerViewIQ.OrderBy(s => s.company_kana);
                        break;
                    default:
                        CustomerViewIQ = CustomerViewIQ.OrderBy(s => s.Id);
                        break;
                }
                vw_customer = await CustomerViewIQ.AsNoTracking().ToListAsync();
            }
        }
    }
}
