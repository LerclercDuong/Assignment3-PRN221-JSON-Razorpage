using BOs;
using Daos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service;
using Service.Impl;

namespace PRN221_Assignment3_Json.Pages.AdveritsementPage
{
    public class CreateModel : PageModel
    {
        private readonly IAdvertisementService _advertisementService;
        private readonly IUserService _userService;
        private readonly IKoiFishService _koiFishService;

        [BindProperty]
        public Advertisement Advertisement { get; set; }

        [BindProperty]
        public List<SelectListItem> KoiFishList { get; set; }

        [BindProperty]
        public string UserId { get; set; }

        public CreateModel()
        {
            _advertisementService = new AdvertisementService();
            _userService = new UserService();
            _koiFishService = new KoiFishService();
        }

        public async Task<IActionResult> OnGetAsync()
        {
            string id = HttpContext.Session.GetString("UserId");
            string Email = HttpContext.Session.GetString("Email");
            string UserRole = HttpContext.Session.GetString("UserRole");
            if (Email == null || UserRole == null)
            {
                TempData["Message"] = "You don't have permission";
                return RedirectToPage("/Index");
            }
            UserId = id;
            var koiFishList = _koiFishService.GetFishList(); // Assuming this is an async method

            // Convert KoiFish objects to SelectListItem
            KoiFishList = koiFishList.Select(k => new SelectListItem
            {
                Value = k.Id, 
                Text = k.KoiFishName,
            }).ToList();

            ViewData["KoiFishId"] = new SelectList(KoiFishList, "KoiFishId", "KoiFishName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Save the advertisement (adjust service as needed)
            var success = _advertisementService.CreateAdvertisement(Advertisement);

            if (success)
            {
                return RedirectToPage("/AdvertisementPage/Index"); // Redirect to the list of ads
            }

            return Page(); // Stay on the page if creation fails
        }
    }
}
