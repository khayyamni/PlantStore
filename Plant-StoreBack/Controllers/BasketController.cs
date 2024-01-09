using Microsoft.AspNetCore.Mvc;

namespace Plant_StoreBack.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
