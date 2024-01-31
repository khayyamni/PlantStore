using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Plant_StoreBack.Helpers.Extensions;
using Plant_StoreBack.Services;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels.Blog;
using Plant_StoreBack.ViewModels.Testimonial;

namespace Plant_StoreBack.Areas.Admin.Controllers
{
    public class TestimonialsController : MainController
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;
        public TestimonialsController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _testimonialService.GetAllAsync());
        }


		[HttpGet]
		public async Task<IActionResult> Detail(int? id)
		{
			if (id is null) return RedirectToAction("Index", "Error");

			TestimonialVM testimonial = await _testimonialService.GetDataIdAsync((int)id);

			if (testimonial is null) return RedirectToAction("Index", "Error");

			return View(testimonial);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(TestimonialCreateVM request)

		{
			if (!ModelState.IsValid)
			{
				return View(request);
			}

			if (!request.Photo.CheckFileType("image/"))
			{
				ModelState.AddModelError("Photo", "File can be only image format");
				return View();
			}

			if (!request.Photo.CheckFileSize(500))
			{
				ModelState.AddModelError("Photo", "File size can be max 500 kb");
				return View();
			}

			await _testimonialService.CreateAsync(request);

			return RedirectToAction(nameof(Index));
		}


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _testimonialService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            TestimonialVM testimonial = await _testimonialService.GetDataIdAsync((int)id);

            if (testimonial is null) return NotFound();

            TestimonialEditVM testimonialEditVM = _mapper.Map<TestimonialEditVM>(testimonial);

            return View(testimonialEditVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, TestimonialEditVM request)
        {
            if (id is null) return BadRequest();

            TestimonialVM dbTestimonail = await _testimonialService.GetDataIdAsync((int)id);

            if (dbTestimonail is null) return NotFound();


            request.Image = dbTestimonail.Image;

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


            await _testimonialService.EditAsync(request);

            return RedirectToAction(nameof(Index));
        }


    }
}
