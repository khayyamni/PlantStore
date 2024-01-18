using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Plant_StoreBack.Data;
using Plant_StoreBack.Models;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels.Product;

namespace Plant_StoreBack.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IProductService _productService;
        private readonly UserManager<AppUser> _userManager;


        public ShopController(AppDbContext context, 
                              IProductService productService,
                              UserManager<AppUser> userManager)
        {
            _context = context;
            _productService = productService;
            _userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {

            int productCount = await _context.Products.Where(m => !m.SoftDeleted).CountAsync();

            ViewBag.count = productCount;

            List<ProductVM> products = await _productService.GetAllWithImagesByTakeAsync(6);

            return View(products);
        }

        public async Task <IActionResult> ProductDetails(int? id) 
        {
            if (id is null) return BadRequest();
            ProductVM product = await _productService.GetByIdAsync((int)id);
            if(product == null) return NotFound();
            return View(product);
        }

    }
}
