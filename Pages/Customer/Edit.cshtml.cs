using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CustomerManagementSystem.Models;

namespace CustomerManagementSystem.Pages.Customer
{
    public class EditModel : PageModel
    {
        private readonly CustomerManagementSystem.Models.MyContext _context;

        public EditModel(CustomerManagementSystem.Models.MyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public tbl_customer tbl_customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Customer == null)
            {
                return NotFound();
            }

            var tbl_customerL =  await _context.Customer.FirstOrDefaultAsync(m => m.Id == id);
            if (tbl_customerL == null)
            {
                return NotFound();
            }
            tbl_customer = tbl_customerL;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string s_button)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (id == null || _context.Customer == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (s_button != null && s_button == "キャンセル") { 
                return RedirectToPage("./Edit?id=" + id.ToString() );
            }

            _context.Attach(tbl_customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_customerExists(tbl_customer.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./../CustomerView/Details?id=" + id.ToString());
        }

        private bool tbl_customerExists(int id)
        {
          return _context.Customer.Any(e => e.Id == id);
        }
    }
}
