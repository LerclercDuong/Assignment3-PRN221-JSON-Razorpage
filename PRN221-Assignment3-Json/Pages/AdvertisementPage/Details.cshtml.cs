using BOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;
using Service.Impl;

namespace PRN221_Assignment3_Json.Pages.AdveritsementPage
{
    public class DetailsModel : PageModel
    {
        public readonly IAdvertisementService advertisementService;
        public readonly IUserService userService;
        public readonly IKoiFishService koiFishService;

        [BindProperty(SupportsGet = true)]
        public int adsId { get; set; }
        public DetailsModel()
        {
            advertisementService = new AdvertisementService();
            userService = new UserService();
            koiFishService = new KoiFishService();
        }

        [BindProperty] 
        public Advertisement advertisement { get; set; }

        [BindProperty]
        public User postedBy { get; set; }

        [BindProperty]
        public KoiFish koiFish { get; set; }

        public async Task<IActionResult> OnGetAsync() {
            advertisement = advertisementService.GetAdvertisement(adsId);
            if (advertisement != null) {
                postedBy = userService.GetUserById(advertisement.PostedByUserId);
                koiFish = koiFishService.GetFishById(advertisement.KoiFishId);
            }
            return Page();
        } 
    }
}
