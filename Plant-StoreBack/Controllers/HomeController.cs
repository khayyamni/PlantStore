using Microsoft.AspNetCore.Mvc;

namespace Plant_StoreBack.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
