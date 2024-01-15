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

        public ShopController(AppDbContext context, IProductService productService)
        {
            _context = context;
            _productService = productService;
        }


        public async Task<IActionResult> Index()
        {

            int productCount = await _context.Products.Where(m => !m.SoftDeleted).CountAsync();

            ViewBag.count = productCount;

            List<ProductVM> products = await _productService.GetAllWithImagesByTakeAsync(6);

            return View(products);
        }
    }
}
