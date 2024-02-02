using Microsoft.AspNetCore.Mvc;
using Plant_StoreBack.Services;
using Plant_StoreBack.Services.Interfaces;

namespace Plant_StoreBack.Controllers
{
    public class BasketController : Controller
    {
        private readonly ISettingsService _settingService;
        private readonly IBasketService _basketService;
        public BasketController(ISettingsService settingService, IBasketService basketService)
        {
            _settingService = settingService;
            _basketService = basketService;

        }
        public async Task<IActionResult> Index()
        {
            Dictionary<string, string> basketBanner = _settingService.GetSettings();
            ViewBag.BasketBanner = basketBanner["BasketBanner"];

            return View(await _basketService.GetBasketDatasAsync());
        }



        [HttpPost]
        public async Task<IActionResult> PlusIcon(int id)
        {
            var data = await _basketService.PlusIcon(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> MinusIcon(int id)
        {
            var data = await _basketService.MinusIcon(id);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _basketService.DeleteItem(id);

            return Ok(data);
        }
    }
}
