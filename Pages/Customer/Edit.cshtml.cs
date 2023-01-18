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


        public SelectList? CompanySL { get; set; }

        public void PopulateCompanyDropDownList(MyContext _context,
            object selectedCompany = null)
        {
            var staffQuery = from d in _context.Company
                             orderby d.company_kana // Sort by staff_name.
                             select d;

            CompanySL = new SelectList(staffQuery, // items       
                        "Id",                   // dataValueField
                        "company_name",           // dataTextField
                        selectedCompany);         // selectedValue
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Customer == null)
            {
                return NotFound();
            }

            var tbl_customerL = await _context.Customer.FirstOrDefaultAsync(m => m.Id == id);
            if (tbl_customerL == null)
            {
                return NotFound();
            }
            tbl_customer = tbl_customerL;

            PopulateCompanyDropDownList(_context);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string action_button)
        {
            if (action_button == "キャンセル")
            {
                //           return RedirectToPage("./Index");
                return RedirectToPage("./Details", new { id = tbl_customer.Id });
            }

            if (!ModelState.IsValid)
            {
                return Page();
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

            //           return RedirectToPage("./Index");
            return RedirectToPage("./Details", new { id = tbl_customer.Id });
        }

        private bool tbl_customerExists(int id)
        {
            return _context.Customer.Any(e => e.Id == id);
        }
    }
}