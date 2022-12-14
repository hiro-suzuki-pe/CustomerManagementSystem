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
        public string CompanyNameSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<vw_customer> vw_customer { get;set; } = default!;

        public async Task OnGetAsync(string sortOrder, string searchCustomer, string searchCompany, string searchMyCustomer)
        {
            if (_context.CustomerView != null)
            {
 //               CurrentFilter = searchCustomer;

                IQueryable<vw_customer> CustomerViewIQ = 
                    from s in _context.CustomerView select s;
                if (!String.IsNullOrEmpty(searchCustomer) && !String.IsNullOrEmpty(searchCompany))
                {
                    CustomerViewIQ =
                        CustomerViewIQ.Where(s => s.customer_name.Contains(searchCustomer)
                            && s.company_name.Contains(searchCompany));
                } else if (!String.IsNullOrEmpty(searchCustomer))
                {
                    CustomerViewIQ =
                        CustomerViewIQ.Where(s => s.customer_name.Contains(searchCustomer));
                } else if (!String.IsNullOrEmpty(searchCompany))
                {
                    CustomerViewIQ =
                        CustomerViewIQ.Where(s => s.company_name.Contains(searchCompany));
                }

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
