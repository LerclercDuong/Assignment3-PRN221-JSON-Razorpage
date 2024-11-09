using BOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;
using Service.Impl;

namespace PRN221_Assignment3_Json.Pages.KoiFishPage
{
    public class IndexModel : PageModel
    {
        public readonly IKoiFishService _koiFishService;
        [BindProperty]
        public List<KoiFish> koi { get; set; }

        public IndexModel()
        {
            _koiFishService = new KoiFishService();

        }

        public void OnGet()
        {
            koi = _koiFishService.GetFishList();
        }
    }
}
