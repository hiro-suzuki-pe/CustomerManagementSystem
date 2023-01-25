using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CustomerManagementSystem.Models;
using System.Security.Cryptography;

namespace CustomerManagementSystem.Pages.Customer
{
    public class CreateModel : PageModel
    {
        private readonly CustomerManagementSystem.Models.MyContext _context;

        public CreateModel(CustomerManagementSystem.Models.MyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public tbl_customer tbl_customer { get; set; } = default!;
        public tbl_staff tbl_staff { get; set; } = default!;


        public SelectList? CompanySL { get; set; }
        public DateTime JustNow;

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
        public SelectList? StaffSL { get; set; }
        public void PopulateStaffDropDownList(MyContext _context,
            object selectedStaff = null)
        {
            var staffQuery = from d in _context.Staff
                             orderby d.staff_name // Sort by staff_name.
                             select d;

            StaffSL = new SelectList(staffQuery, // items       
                        "Id",                   // dataValueField
                        "staff_name",           // dataTextField
                        selectedStaff);         // selectedValue
        }
        public async Task<IActionResult> OnGetAsync()
        {
            JustNow = DateTime.Now;
            PopulateCompanyDropDownList(_context);
            PopulateStaffDropDownList(_context);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string action_button)
        {
            tbl_staff = await _context.Staff.FirstOrDefaultAsync(m => m.Id == tbl_customer.staffId);
            if (action_button == "キャンセル")
            {
                //           return RedirectToPage("./Index");
                return RedirectToPage("./Index");
            }

            tbl_customer.input_staff_name = tbl_staff.staff_name;
            tbl_customer.input_date = tbl_customer.first_action_date;
            tbl_customer.update_staff_name = tbl_staff.staff_name;
            tbl_customer.update_date = tbl_customer.first_action_date;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Add(tbl_customer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                    throw;
            }

            return RedirectToPage("./Index");
        }

        private bool tbl_customerExists(int id)
        {
            return _context.Customer.Any(e => e.Id == id);
        }
    }
}