using BOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;
using Service.Impl;

namespace PRN221_Assignment3_Json.Pages.AdvertisementPage
{
    public class AdvertisementViewModel
    {
        public int AdvertisementId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public List<string> KoiFishPictures { get; set; } 
        public string KoiFishName { get; set; }
        public string KoiFishSize { get; set; }
        public string KoiFishColor { get; set; }
        
        public string PostedByName { get; set; }
        public string PostedByEmail { get; set; }
    }

    public class IndexModel : PageModel
    {
        private readonly IAdvertisementService advertisementService;
        private readonly IUserService userService;
        private readonly IKoiFishService koiFishService;

        public IndexModel()
        {
            advertisementService = new AdvertisementService();
            userService = new UserService();
            koiFishService = new KoiFishService();
        }

        [BindProperty]
        public List<AdvertisementViewModel> Advertisements { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var ads = advertisementService.GetAdvertisements();
            Advertisements = new List<AdvertisementViewModel>();

            foreach (var ad in ads)
            {
                var koiFish = koiFishService.GetFishById(ad.KoiFishId);
                var postedByUser = userService.GetUserById(ad.PostedByUserId);

                Advertisements.Add(new AdvertisementViewModel
                {
                    AdvertisementId = ad.AdvertisementId,
                    Title = ad.Title,
                    Description = ad.Description,
                    Price = ad.Price,
                    KoiFishName = koiFish?.KoiFishName,
                    KoiFishSize = koiFish?.KoiFishSize.ToString(),
                    KoiFishColor = koiFish?.KoiFishColor,
                    KoiFishPictures = koiFish?.KoiFishPictures ?? new List<string>(),
                    PostedByName = postedByUser?.Username,
                    PostedByEmail = postedByUser?.Email
                });
            }

            return Page();
        }
    }
}
