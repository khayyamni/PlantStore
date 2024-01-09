using Microsoft.AspNetCore.Mvc;
using Plant_StoreBack.Services;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels;
using Plant_StoreBack.ViewModels.Banner;
using Plant_StoreBack.ViewModels.Blog;
using Plant_StoreBack.ViewModels.Elementor;
using Plant_StoreBack.ViewModels.Featured;
using Plant_StoreBack.ViewModels.Home;

namespace Plant_StoreBack.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBannerService _bannerService;
        private readonly IElementorService _elementorService;
        private readonly IBlogService _blogService;
        private readonly IFeaturedService _featuredService;
        public HomeController(IBannerService bannerService,
                              IElementorService elementorService,
                              IBlogService blogService,
                              IFeaturedService featuredService)
        {
             _bannerService = bannerService;
            _elementorService = elementorService; 
            _blogService = blogService;
            _featuredService = featuredService;
        }
        public async Task<IActionResult> Index()
        {
            BannerVM banner = await _bannerService.GetDataAsync();
            List<ElementorVM> elementors = await _elementorService.GetAllAsync();
            List<BlogVM> blogs = await _blogService.GetAllAsync();
            FeaturedVM featured = await _featuredService.GetDataAsync();



            HomeVM model = new()
            {
             Banner = banner,
             Elementors = elementors,
             Blogs = blogs,
             Featured = featured

            };
            return View(model);
        }
    }
}
