using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CustomerManagementSystem.Models;

namespace CustomerManagementSystem.Pages.Test
{
    public class IndexModel : PageModel
    {
        private readonly CustomerManagementSystem.Models.MyContext _context;

        public IndexModel(CustomerManagementSystem.Models.MyContext context)
        {
            _context = context;
        }

        public IList<Testx> Test { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Test != null)
            {
                Test = await _context.Test.ToListAsync();
            }
        }
    }
}
