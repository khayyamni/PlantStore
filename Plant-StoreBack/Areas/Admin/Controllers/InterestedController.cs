using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Plant_StoreBack.Helpers.Extensions;
using Plant_StoreBack.Services;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels.Blog;
using Plant_StoreBack.ViewModels.Interested;

namespace Plant_StoreBack.Areas.Admin.Controllers
{
    public class InterestedController : MainController
    {
        private readonly IInterestedService _interestedService;
        private readonly IMapper _mapper;
        public InterestedController(IInterestedService interestedService, IMapper mapper)
        {
            _interestedService = interestedService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _interestedService.GetDataAsync());

        }


		[HttpGet]
		public async Task<IActionResult> Detail(int? id)
		{
			if (id is null) return RedirectToAction("Index", "Error");

			InterestedVM interested = await _interestedService.GetDataIdAsync((int)id);

			if (interested is null) return RedirectToAction("Index", "Error");

			return View(interested);
		}




        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            InterestedVM data = await _interestedService.GetDataIdAsync((int)id);

            if (data is null) return NotFound();

            InterestedEditVM interestedEditVM = _mapper.Map<InterestedEditVM>(data);

            return View(interestedEditVM);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, InterestedEditVM request)
        {
            if (id is null) return BadRequest();

            InterestedVM dbInterested = await _interestedService.GetDataIdAsync((int)id);

            if (dbInterested is null) return NotFound();


            request.Image = dbInterested.Image;

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


            await _interestedService.EditAsync(request);

            return RedirectToAction(nameof(Index));
        }



    }
}
