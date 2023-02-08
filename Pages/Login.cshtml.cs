using CustomerManagementSystem.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Cryptography;

namespace CustomerManagementSystem.Pages
{


    public class LoginModel : PageModel
    {
        private readonly CustomerManagementSystem.Models.MyContext _context;
        private ILogger _logger;

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

        /*
         * private string AuthenticateUser(string UserId, string Password)
               {
                   var staff = await _context.Staff.FirstOrDefaultAsync(m => m.userId == UserId);

                   if (staff == null)
                   {
                       return null;
                   }
                   if (staff.password != Password)
                   {
                       return null;
                   };
                   return staff.userId;
               }
       */
//        public async Task<IActionResult> OnPostAsync(string StaffUserId, string StaffPassword,
//            string ReturnUrl = null)
       public async Task<IActionResult> OnPostAsync(string StaffUserId, string StaffPassword,
           string? returnUrl = null)
        {

            returnUrl = returnUrl;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            //            var user = await AuthenticateUser(StaffUserId, StaffPassword);
            var user = await _context.Staff.FirstOrDefaultAsync(m => m.userId == StaffUserId);
            if (user == null || user.password != StaffPassword)
            {
                ModelState.AddModelError(string.Empty, "ÉçÉOÉCÉìÇÕé∏îsÇµÇ‹ÇµÇΩÅB");
                return Page();
            }

            var claims = new List<Claim>
            {
                new Claim("UserId", StaffUserId),
                new Claim("Password", StaffPassword)    //,
                //                new Claim("Admin_flag", "false")
            };

            var claimsIdentity = new ClaimsIdentity(
                claims,  CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                IsPersistent = true,
                IssuedUtc = DateTime.Now,       // <DateTimeOffset>,
                RedirectUri = "string",

                //AllowRefresh = <bool>,
                // Refreshing the authentication session should be allowed.

                //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.

                //IsPersistent = true,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.

                //IssuedUtc = <DateTimeOffset>,
                // The time at which the authentication ticket was issued.

                //RedirectUri = <string>
                // The full path or absolute URI to be used as an http 
                // redirect response value.
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), authProperties);
            // var tbl_staffL = await _context.Staff.FirstOrDefaultAsync(m => m.userId == StaffUserId);

            // _logger.LogInformation("User {UserId} logged in at {Time}.",
            //    StaffUserId, DateTime.UtcNow);
            //
            // return RedirectToPage("./Index");
            //            return LocalRedirect(Url.GetLocalUrl(returnUrl));


            /*
            if (tbl_staffL == null)
            {
                return Page();
            };
            if (tbl_staffL.password != StaffPassword)
            {
                return Page();
            };
            */

            return RedirectToPage("./Index");
        }

    }
}
