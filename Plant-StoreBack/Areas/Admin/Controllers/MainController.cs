using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Plant_StoreBack.Helpers.Enums;

namespace Plant_StoreBack.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class MainController : Controller
    {

    }
}
