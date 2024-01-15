using Microsoft.AspNetCore.Mvc;
using Plant_StoreBack.Services.Interfaces;

namespace Plant_StoreBack.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _categoryService.GetAllAsync());
        }

    }
}
