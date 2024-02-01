using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels.Elementor;
using Plant_StoreBack.ViewModels.Help;

namespace Plant_StoreBack.Areas.Admin.Controllers
{
    public class ElementorController : MainController
    {
        private readonly IElementorService _elementorService;
        private readonly IMapper _mapper;
        public ElementorController(IElementorService elementorService, IMapper mapper)
        {
            _elementorService = elementorService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _elementorService.GetAllAsync());
        }


		[HttpGet]
		public async Task<IActionResult> Detail(int? id)
		{
			if (id is null) return RedirectToAction("Index", "Error");

			ElementorVM elementor = await _elementorService.GetDataIdAsync((int)id);

			if (elementor is null) return RedirectToAction("Index", "Error");

			return View(elementor);
		}


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            ElementorVM elementor = await _elementorService.GetDataIdAsync((int)id);

            if (elementor is null) return NotFound();

            ElementorEditVM elementorEditVM = _mapper.Map<ElementorEditVM>(elementor);

            return View(elementorEditVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, ElementorEditVM request)
        {
            if (id is null) return BadRequest();

            ElementorVM dbElementor = await _elementorService.GetDataIdAsync((int)id);

            if (dbElementor is null) return NotFound();



            await _elementorService.EditAsync(request);

            return RedirectToAction(nameof(Index));
        }

    }
}
