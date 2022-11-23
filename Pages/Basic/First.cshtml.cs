using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerManagementSystem.Pages.Basic
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; } = "";
        public IActionResult OnGet()
        {
            Message = "Ç±ÇÒÇ…ÇøÇÕÅAê¢äE";
            return Page();
        }
    }
}
