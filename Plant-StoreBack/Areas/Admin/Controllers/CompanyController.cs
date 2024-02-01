using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Plant_StoreBack.Helpers.Extensions;
using Plant_StoreBack.Services;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels.Blog;
using Plant_StoreBack.ViewModels.Company;
using Plant_StoreBack.ViewModels.Interested;

namespace Plant_StoreBack.Areas.Admin.Controllers
{
    public class CompanyController : MainController
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _companyService.GetAllAsync());
        }

		[HttpGet]
		public async Task<IActionResult> Detail(int? id)
		{
			if (id is null) return RedirectToAction("Index", "Error");

			CompanyVM company = await _companyService.GetByIdAsync((int)id);

			if (company is null) return RedirectToAction("Index", "Error");

			return View(company);
		}


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            CompanyVM company = await _companyService.GetByIdAsync((int)id);

            if (company is null) return NotFound();

            CompanyEditVM companyEditVM = _mapper.Map<CompanyEditVM>(company);

            return View(companyEditVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, CompanyEditVM request)
        {
            if (id is null) return BadRequest();

            CompanyVM dbCompany = await _companyService.GetByIdAsync((int)id);

            if (dbCompany is null) return NotFound();


            request.Image = dbCompany.Image;

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


            await _companyService.EditAsync(request);

            return RedirectToAction(nameof(Index));
        }

    }
}
