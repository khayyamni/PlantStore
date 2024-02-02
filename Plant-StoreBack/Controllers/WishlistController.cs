using Microsoft.AspNetCore.Mvc;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels.Wishlist;

namespace Plant_StoreBack.Controllers
{
    public class WishlistController : Controller
    {
        private readonly ISettingsService _settingService;
        private readonly IWishlistService _wishlistService;

        public WishlistController(ISettingsService settingService, IWishlistService wishlistService)
        {
            _settingService = settingService;
            _wishlistService = wishlistService;
        }

        public async Task<IActionResult> Index()
        {
            Dictionary<string, string> wishlistBanner = _settingService.GetSettings();
            ViewBag.WishlistBanner = wishlistBanner["WishlistBanner"];

            return View(await _wishlistService.GetWishlistDatasAsync());

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _wishlistService.DeleteItem(id);
            List<WishlistVM> wishlist = _wishlistService.GetDatasFromCoockies();

            return Ok(wishlist.Count);
        }
    }
}
