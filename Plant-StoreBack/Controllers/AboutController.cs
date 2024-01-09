using Microsoft.AspNetCore.Mvc;

namespace Plant_StoreBack.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
