using CustomerManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace CustomerManagementSystem.Pages
{


    public class LoginModel : PageModel
    {

        private readonly CustomerManagementSystem.Models.MyContext _context;

        public LoginModel(CustomerManagementSystem.Models.MyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public tbl_staff tbl_staff { get; set; } = default!;
//        public string StaffUserId { get; set; }
//        public string StaffPassword { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string StaffUserId, string StaffPassword)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var tbl_staffL = await _context.Staff.FirstOrDefaultAsync(m => m.userId == StaffUserId);

            if (tbl_staffL == null)
            {
                return Page();
            };
            if (tbl_staffL.password != StaffPassword)
            {
                return Page();
            };

            return RedirectToPage("./Index");
        }

    }
}
