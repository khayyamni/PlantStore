using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Plant_StoreBack.Helpers.Extensions;
using Plant_StoreBack.Services;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels.Banner;
using Plant_StoreBack.ViewModels.Team;

namespace Plant_StoreBack.Areas.Admin.Controllers
{
    public class BannerController : MainController
    {
        private readonly IBannerService _bannerService;
        private readonly IMapper _mapper;
        public BannerController(IBannerService bannerService, IMapper mapper)
        {
            _bannerService = bannerService;
			_mapper = mapper;
        }       

        public async Task<IActionResult> Index()
        {
            return View(await _bannerService.GetDataAsync());
        }

		[HttpGet]
		public async Task<IActionResult> Detail(int? id)
		{
			if (id is null) return RedirectToAction("Index", "Error");

			BannerVM banner = await _bannerService.GetDataIdAsync((int)id);

			if (banner is null) return RedirectToAction("Index", "Error");

			return View(banner);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int? id)
		{
			if (id is null) return BadRequest();

			BannerVM banner = await _bannerService.GetDataIdAsync((int)id);

			if (banner is null) return NotFound();

            BannerEditVM bannerEditVM = _mapper.Map<BannerEditVM>(banner);

			return View(bannerEditVM);
		}


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, BannerEditVM request)
        {
            if (id is null) return BadRequest();

            BannerVM dbBanner = await _bannerService.GetDataIdAsync((int)id);

            if (dbBanner is null) return NotFound();


            request.Image = dbBanner.Image;

            if (!ModelState.IsValid)
            {
                return View(request);

            }

            if (request.Photo is not null)
            {
                if (!request.Photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photo", "File can be only image format");
                    return View(request);
                }
                if (!request.Photo.CheckFileSize(500))
                {
                    ModelState.AddModelError("Photo", "File size can be max 500 kb");
                    return View(request);
                }
            }


            await _bannerService.EditAsync(request);

            return RedirectToAction(nameof(Index));
        }


    }
}
