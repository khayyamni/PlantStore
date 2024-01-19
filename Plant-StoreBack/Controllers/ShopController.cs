using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Plant_StoreBack.Data;
using Plant_StoreBack.Models;
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


        public ShopController(AppDbContext context, 
                              IProductService productService,
                              ICategoryService categoryService,
                              UserManager<AppUser> userManager)
        {
            _context = context;
            _productService = productService;
            _userManager = userManager;
            _categoryService = categoryService;
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

    }
}
