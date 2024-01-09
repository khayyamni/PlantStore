using Microsoft.AspNetCore.Mvc;

namespace Plant_StoreBack.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
