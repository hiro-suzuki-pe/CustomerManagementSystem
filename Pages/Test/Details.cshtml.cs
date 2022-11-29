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
    public class DetailsModel : PageModel
    {
        private readonly CustomerManagementSystem.Models.MyContext _context;

        public DetailsModel(CustomerManagementSystem.Models.MyContext context)
        {
            _context = context;
        }

      public Testx Test { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Test == null)
            {
                return NotFound();
            }

            var test = await _context.Test.FirstOrDefaultAsync(m => m.Id == id);
            if (test == null)
            {
                return NotFound();
            }
            else 
            {
                Test = test;
            }
            return Page();
        }
    }
}
