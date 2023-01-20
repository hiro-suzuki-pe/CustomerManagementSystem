using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CustomerManagementSystem.Models;

namespace CustomerManagementSystem.Pages.Action
{
    public class EditModel : PageModel
    {
        private readonly CustomerManagementSystem.Models.MyContext _context;

        public EditModel(CustomerManagementSystem.Models.MyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public tbl_action tbl_action { get; set; } = default!;
        public tbl_customer tbl_customer { get; set; } = default!;
        public tbl_company tbl_company { get; set; } = default!;
        public tbl_staff tbl_staff { get; set; } = default!;

        public SelectList? StaffSL { get; set; }
        public void PopulateStaffDropDownList(MyContext _context,
            object selectedStaff = null)
        {
            var staffQuery = from d in _context.Staff
                             orderby d.Id // Sort by staff_name.
                             select d;

            StaffSL = new SelectList(staffQuery, // items       
                        "Id",                   // dataValueField
                        "staff_name",           // dataTextField
                        selectedStaff);         // selectedValue
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Action == null)
            {
                return NotFound();
            }

            tbl_action = await _context.Action.FirstOrDefaultAsync(m => m.Id == id);
            if (tbl_action == null)
            {
                return NotFound();
            }

            tbl_customer = await _context.Customer.FirstOrDefaultAsync(m => m.Id == tbl_action.customerId);
            if (tbl_customer == null)
            {
                return NotFound();
            }

            tbl_company = await _context.Company.FirstOrDefaultAsync(m => m.Id == tbl_customer.companyId);
            if (tbl_company == null)
            {
                return NotFound();
            }

            tbl_staff = await _context.Staff.FirstOrDefaultAsync(m => m.Id == tbl_action.action_staffId);
            if (tbl_staff == null)
            {
                return NotFound();
            }

            PopulateStaffDropDownList(_context);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string action_button, int id)
        {
            tbl_customer = await _context.Customer.FirstOrDefaultAsync(m => m.Id == tbl_action.customerId);
            if (tbl_customer == null)
            {
                return NotFound();
            }

            if (action_button == "キャンセル")
            {
                //           return RedirectToPage("./Index");
                return RedirectToPage("../Customer/Details", new { id = tbl_customer.Id });
            }


            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(tbl_action).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_actionExists(tbl_action.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("../Customer/Details", new { id = tbl_customer.Id });
        }

        private bool tbl_actionExists(int id)
        {
          return _context.Action.Any(e => e.Id == id);
        }
    }
}
