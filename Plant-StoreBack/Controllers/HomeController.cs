using Microsoft.AspNetCore.Mvc;
using Plant_StoreBack.Models;
using Plant_StoreBack.Services;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels;
using Plant_StoreBack.ViewModels.Banner;
using Plant_StoreBack.ViewModels.Blog;
using Plant_StoreBack.ViewModels.Elementor;
using Plant_StoreBack.ViewModels.Featured;
using Plant_StoreBack.ViewModels.Help;
using Plant_StoreBack.ViewModels.Home;
using Plant_StoreBack.ViewModels.Interested;
using Plant_StoreBack.ViewModels.Product;
using Plant_StoreBack.ViewModels.Testimonial;

namespace Plant_StoreBack.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBannerService _bannerService;
        private readonly IElementorService _elementorService;
        private readonly IBlogService _blogService;
        private readonly IFeaturedService _featuredService;
        private readonly IHelpsService _helpsService;
        private readonly IInterestedService  _interestedService;
        private readonly IProductService _productService;
        private readonly ITestimonialService _testimonialService;
        public HomeController(IBannerService bannerService,
                              IElementorService elementorService,
                              IBlogService blogService,
                              IFeaturedService featuredService,
                              IHelpsService helpsService,
                              IInterestedService interestedService,
                              IProductService productService,
                              ITestimonialService testimonialService)
        {
             _bannerService = bannerService;
            _elementorService = elementorService; 
            _blogService = blogService;
            _featuredService = featuredService;
            _helpsService = helpsService;
            _interestedService = interestedService;
            _productService = productService;
            _testimonialService = testimonialService;
        }
        public async Task<IActionResult> Index()
        {
            BannerVM banner = await _bannerService.GetDataAsync();
            List<ElementorVM> elementors = await _elementorService.GetAllAsync();
            List<BlogVM> blogs = await _blogService.GetAllAsync();
            FeaturedVM featured = await _featuredService.GetDataAsync();
            HelpVM help = await _helpsService.GetDataAsync();
            InterestedVM interested = await _interestedService.GetDataAsync();
            List<ProductVM> products = await _productService.GetAllWithImagesByTakeAsync(8);
            List<TestimonialVM> testimonials = await _testimonialService.GetAllAsync();





            HomeVM model = new()
            {
             Banner = banner,
             Elementors = elementors,
             Blogs = blogs,
             Featured = featured,
             Help = help,
             Interested = interested,
             Product = products,
             Testimonial = testimonials

            };
            return View(model);
        }
    }
}
