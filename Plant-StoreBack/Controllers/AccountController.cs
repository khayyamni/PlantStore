using Microsoft.AspNetCore.Mvc;

namespace Plant_StoreBack.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
