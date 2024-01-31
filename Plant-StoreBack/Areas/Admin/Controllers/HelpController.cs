using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Plant_StoreBack.Helpers.Extensions;
using Plant_StoreBack.Services;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels.Blog;
using Plant_StoreBack.ViewModels.Help;

namespace Plant_StoreBack.Areas.Admin.Controllers
{
    public class HelpController : MainController
    {
        private readonly IHelpsService _helpService;
        private readonly IMapper _mapper;
        public HelpController(IHelpsService helpsService, IMapper mapper)
        {
            _helpService = helpsService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _helpService.GetDataAsync());
        }


		[HttpGet]
		public async Task<IActionResult> Detail(int? id)
		{
			if (id is null) return RedirectToAction("Index", "Error");

			HelpVM help = await _helpService.GetDataIdAsync((int)id);

			if (help is null) return RedirectToAction("Index", "Error");

			return View(help);
		}


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            HelpVM help = await _helpService.GetDataIdAsync((int)id);

            if (help is null) return NotFound();

            HelpEditVM helpEditVM = _mapper.Map<HelpEditVM>(help);

            return View(helpEditVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, HelpEditVM request)
        {
            if (id is null) return BadRequest();

            HelpVM dbHelp = await _helpService.GetDataIdAsync((int)id);

            if (dbHelp is null) return NotFound();



            await _helpService.EditAsync(request);

            return RedirectToAction(nameof(Index));
        }

    }
}
