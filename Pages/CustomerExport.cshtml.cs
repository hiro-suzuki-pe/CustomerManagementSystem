using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CustomerManagementSystem.Models;

namespace CustomerManagementSystem.Pages
{

    public class CustomerExportModel : PageModel
    {
        private readonly MyContext _context;
        
        public CustomerExportModel(MyContext context)
        {
            _context = context;
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

        public IActionResult OnGet()
        {
            PopulateStaffDropDownList(_context);
            return Page();
        }
    }
}
