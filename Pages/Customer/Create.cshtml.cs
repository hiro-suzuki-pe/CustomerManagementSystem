using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CustomerManagementSystem.Models;

namespace CustomerManagementSystem.Pages.Customer
{
    public class CreateModel : PageModel
    {
        private readonly CustomerManagementSystem.Models.MyContext _context;

        public CreateModel(CustomerManagementSystem.Models.MyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public tbl_customer tbl_customer { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Customer.Add(tbl_customer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
