using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PRN221_Assignment3_Json.Pages
{
    public class HomeModel : PageModel
    {

        [BindProperty] public string Email { get; set; }
        [BindProperty] public string UserRole { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Email = HttpContext.Session.GetString("Email");
            UserRole = HttpContext.Session.GetString("UserRole");
            if (Email == null || UserRole == null) {
                TempData["Message"] = "You don't have permission";
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}
