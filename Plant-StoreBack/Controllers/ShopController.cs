using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Plant_StoreBack.Data;
using Plant_StoreBack.Models;
using Plant_StoreBack.Services;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels.Category;
using Plant_StoreBack.ViewModels.Product;
using Plant_StoreBack.ViewModels.Shop;

namespace Plant_StoreBack.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ISettingsService _settingService;
        private readonly IBasketService _basketService;
        private readonly IWishlistService _wishlistService;


        public ShopController(AppDbContext context, 
                              IProductService productService,
                              ICategoryService categoryService,
                              UserManager<AppUser> userManager,
                              ISettingsService settingService,
                              IBasketService basketService,
                              IWishlistService wishlistService)
        {
            _context = context;
            _productService = productService;
            _userManager = userManager;
            _categoryService = categoryService;
            _settingService = settingService;
            _basketService = basketService;
            _wishlistService = wishlistService;
        }


        public async Task<IActionResult> Index()
        {

            int productCount = await _context.Products.Where(m => !m.SoftDeleted).CountAsync();

            ViewBag.count = productCount;

            List<ProductVM> products = await _productService.GetAllWithImagesByTakeAsync(12);
            List<CategoryVM> categories = await _categoryService.GetAllAsync();

            ShopVM model = new()
            {
                Product = products,
                Category = categories
            };

            return View(model);
        }

        public async Task <IActionResult> ProductDetails(int? id) 
        {
            if (id is null) return BadRequest();
            ProductVM product = await _productService.GetByIdAsync((int)id);
            if(product == null) return NotFound();
            return View(product);
        }

        public async Task<IActionResult> GetProductsByCategory(int? id) 
        {
            if (id is null) return BadRequest();
            CategoryVM category = await _categoryService.GetCategoryByIdAsync((int)id);
            if (category == null) return NotFound();

            List<ProductVM> product = await _productService.GetByCategoryAsync((int)id);

            List<CategoryVM> categories = await _categoryService.GetAllAsync();

            ShopVM model = new()
            {
                Product = product,
                Category = categories
            };

            return View(model);
        }





        public async Task<IActionResult> Filter(int value1, int value2)
        {

            List<ProductVM> productsByFilter = await _productService.FilterAsync(value1, value2);
            return PartialView("_ProductsPartial", productsByFilter);

        }



        public async Task<IActionResult> Sort(string sortValue)
        {
            List<ProductVM> products = new();

            if (sortValue == "1")
            {
                return RedirectToAction(nameof(Index));
            };
            if (sortValue == "2")
            {
                products = await _productService.OrderByPriceAsc();

            };
            if (sortValue == "3")
            {
                products = await _productService.OrderByPriceDesc();

            };
            if (sortValue == "4")
            {
                products = await _productService.OrderByNameAsc();

            };

            if (sortValue == "5")
            {
                products = await _productService.OrderByNameDesc();

            };

            List<CategoryVM> categories = await _categoryService.GetAllAsync();

            int count = await _productService.GetCountAsync();

            ShopVM model = new()
            {
               Product= products,
                Category = categories
               
            };
            return View(model);
        }




        public async Task<IActionResult> Search(string searchText)
        {

            if (searchText == null)
            {
                return RedirectToAction("Index", "Shop");
            }

            List<CategoryVM> categories = await _categoryService.GetAllAsync();

            List<ProductVM> products = await _productService.SearchAsync(searchText);

            Dictionary<string, string> shopBanner = _settingService.GetSettings();

            ShopVM model = new()
            {
                Category = categories,
                Product = products

            };

            return View(model);
        }




        [HttpPost]

        public async Task<IActionResult> AddBasket(int? id)
        {


            if (id is null) return RedirectToAction("Index", "Error"); ;

            ProductVM product = await _productService.GetByIdAsync((int)id);

            if (product is null) return RedirectToAction("Index", "Error");

            _basketService.AddBasket((int)id, product);


            return Ok();
        }



        [HttpPost]

        public async Task<IActionResult> AddWishlist(int? id)
        {


            if (id is null) return RedirectToAction("Index", "Error"); ;

            ProductVM product = await _productService.GetByIdAsync((int)id);

            if (product is null) return RedirectToAction("Index", "Error"); ;

            int a = _wishlistService.AddWishlist((int)id, product);

            return Ok(a);
        }



    }
}
