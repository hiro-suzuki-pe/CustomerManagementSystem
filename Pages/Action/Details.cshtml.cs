using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CustomerManagementSystem.Models;

namespace CustomerManagementSystem.Pages.Action
{
    public class DetailsModel : PageModel
    {
        private readonly CustomerManagementSystem.Models.MyContext _context;

        public DetailsModel(CustomerManagementSystem.Models.MyContext context)
        {
            _context = context;
        }

      public tbl_action tbl_action { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Action == null)
            {
                return NotFound();
            }

            var tbl_action = await _context.Action.FirstOrDefaultAsync(m => m.Id == id);
            if (tbl_action == null)
            {
                return NotFound();
            }
            else 
            {
                tbl_action = tbl_action;
            }
            return Page();
        }
    }
}
