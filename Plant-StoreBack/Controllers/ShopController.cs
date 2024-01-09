using Microsoft.AspNetCore.Mvc;

namespace Plant_StoreBack.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
