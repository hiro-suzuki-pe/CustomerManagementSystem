using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CustomerManagementSystem.Models;
using Microsoft.Data.SqlClient;

namespace CustomerManagementSystem.Pages.CustomerView
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

        public string CustomerNameSort { get; set; }
        public string CompanyNameSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<vw_customer> vw_customer { get;set; } 

        public async Task OnGetAsync(string sortOrder, string searchCustomer, 
            string searchCompany, string searchMyCustomer, int? pageIndex)
        {
            if (_context.CustomerView == null)
                return;

            if (searchCustomer != null)
            {
                pageIndex = 1;
            } 
            else
            {
                searchCustomer = CurrentFilter;
            }
            CurrentFilter = searchCustomer;

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
            var pageSize = Configuration.GetValue("PageSize", 4);
            vw_customer = await PaginatedList<vw_customer>.CreateAsync(
                CustomerViewIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
