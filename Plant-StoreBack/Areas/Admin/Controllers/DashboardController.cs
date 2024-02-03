using Microsoft.AspNetCore.Mvc;

namespace Plant_StoreBack.Areas.Admin.Controllers
{
    public class DashboardController : MainController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
