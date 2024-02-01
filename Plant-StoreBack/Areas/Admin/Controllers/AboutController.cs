using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels.About;
using Plant_StoreBack.ViewModels.Help;

namespace Plant_StoreBack.Areas.Admin.Controllers
{
    public class AboutController : MainController
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;
        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _aboutService.GetAllAsync());
        }


		[HttpGet]
		public async Task<IActionResult> Detail(int? id)
		{
			if (id is null) return RedirectToAction("Index", "Error");

			AboutVM about = await _aboutService.GetByIdAsync((int)id);

			if (about is null) return RedirectToAction("Index", "Error");

			return View(about);
		}


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            AboutVM help = await _aboutService.GetByIdAsync((int)id);

            if (help is null) return NotFound();

            AboutEditVM helpEditVM = _mapper.Map<AboutEditVM>(help);

            return View(helpEditVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, AboutEditVM request)
        {
            if (id is null) return BadRequest();

            AboutVM dbAbout = await _aboutService.GetByIdAsync((int)id);

            if (dbAbout is null) return NotFound();



            await _aboutService.EditAsync(request);

            return RedirectToAction(nameof(Index));
        }


    }
}
