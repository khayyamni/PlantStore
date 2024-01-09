using Microsoft.AspNetCore.Mvc;

namespace Plant_StoreBack.Controllers
{
    public class WishlistController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
