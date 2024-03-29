﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CustomerManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagementSystem.Pages.Action
{
    public class CreateModel : PageModel
    {
        private readonly CustomerManagementSystem.Models.MyContext _context;
        //  public int cid { get; set; }
        public CreateModel(CustomerManagementSystem.Models.MyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public tbl_action tbl_action { get; set; } = default!;
        public tbl_customer tbl_customer { get; set; } = default!;
        public tbl_company tbl_company { get; set; } = default!;
        public tbl_staff tbl_staff { get; set; } = default!;

        public SelectList? StaffSL { get; set; }

        public int CustomerId { get; set; }
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

        public async Task<IActionResult> OnGetAsync(string? cid)        // id:  customer ID (NOT action ID)
        {
            CustomerId = int.Parse(cid);
            tbl_customer = await _context.Customer.FirstOrDefaultAsync(m => m.Id == int.Parse(cid));
            if (tbl_customer == null)
            {
                return NotFound();
            }

            tbl_company = await _context.Company.FirstOrDefaultAsync(m => m.Id == tbl_customer.companyId);
            if (tbl_company == null)
            {
                return NotFound();
            }

            PopulateStaffDropDownList(_context);
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string action_button)
        {
            if (action_button == "キャンセル")
            {
                //           return RedirectToPage("./Index");
                return RedirectToPage("../Customer/Details", new { id = tbl_action.customerId });
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Action.Add(tbl_action);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return RedirectToPage("../Customer/Details", new { id = tbl_action.customerId });
        }
        private bool tbl_actionExists(int id)
        {
            return _context.Action.Any(e => e.Id == id);
        }
    }
}
