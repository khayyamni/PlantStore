using Microsoft.AspNetCore.Mvc;

namespace Plant_StoreBack.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
