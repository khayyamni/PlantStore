using Microsoft.AspNetCore.Mvc;
using Plant_StoreBack.Services;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels;
using Plant_StoreBack.ViewModels.Banner;
using Plant_StoreBack.ViewModels.Elementor;
using Plant_StoreBack.ViewModels.Home;

namespace Plant_StoreBack.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBannerService _bannerService;
        private readonly IElementorService _elementorService;
        public HomeController(IBannerService bannerService,IElementorService elementorService)
        {
             _bannerService = bannerService;
            _elementorService = elementorService; 
        }
        public async Task<IActionResult> Index()
        {
            BannerVM banner = await _bannerService.GetDataAsync();
            List<ElementorVM> elementors = await _elementorService.GetAllAsync();
            

            HomeVM model = new()
            {
             Banner = banner,
             Elementors = elementors

            };
            return View(model);
        }
    }
}
