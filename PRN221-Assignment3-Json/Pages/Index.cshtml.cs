using BOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;
using Service.Impl;

namespace PRN221_Assignment3_Json.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IUserService _userService;

        [BindProperty]
        public string email { get; set; }

        [BindProperty]
        public string password { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _userService = new UserService();
        }

        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                User user = _userService.GetUser(email, password);
                if (user != null) {
                    HttpContext.Session.SetString("UserId", user.Id);
                    HttpContext.Session.SetString("Email", email);
                    HttpContext.Session.SetString("UserRole", user.Role.ToString());
                    TempData["Message"] = "Login successfully";
                }
                else
                {
                    TempData["Message"] = "Login failed";
                }
                return RedirectToPage("/Home");
            }
            catch (Exception ex) {
                TempData["Message"] = "Login failed";
            }
            return Page();
        }
    }
}
