using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels.Category;
using Plant_StoreBack.ViewModels.Help;

namespace Plant_StoreBack.Areas.Admin.Controllers
{
	public class CategoryController : MainController
	{
		private readonly ICategoryService _categoryService;
		private readonly IMapper _mapper;

		public CategoryController(ICategoryService categoryService, IMapper mapper)
		{
			_categoryService = categoryService;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			return View(await _categoryService.GetAllAsync());
		}


        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return RedirectToAction("Index", "Error");

            CategoryVM category = await _categoryService.GetCategoryByIdAsync((int)id);

            if (category is null) return RedirectToAction("Index", "Error");

            return View(category);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(CategoryCreateVM request)

        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            CategoryVM existCategory = await _categoryService.GetByNameWithoutTrackingAsync(request.Name);

            if (existCategory != null)
            {
                ModelState.AddModelError("Name", "This Category already exists");
                return View();
            }


            await _categoryService.CreateAsync(request);

            return RedirectToAction(nameof(Index));
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }





        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return RedirectToAction("Index", "Error");

            CategoryVM category = await _categoryService.GetCategoryByIdAsync((int)id);

            if (category is null) return RedirectToAction("Index", "Error");

            CategoryEditVM categoryEditVM = _mapper.Map<CategoryEditVM>(category);


            return View(categoryEditVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, CategoryEditVM request)
        {
            if (id is null) return RedirectToAction("Index", "Error");

            CategoryVM dbCategory = await _categoryService.GetCategoryByIdAsync((int)id);

            if (dbCategory is null) return RedirectToAction("Index", "Error");


            CategoryVM existCategory = await _categoryService.GetByNameWithoutTrackingAsync(request.Name);

            if (existCategory != null)
            {
                if (existCategory.Id == request.Id)
                {
                    await _categoryService.EditAsync(request);

                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("Name", "This Tag already exists");
                return View(request);
            }

            await _categoryService.EditAsync(request);

            return RedirectToAction(nameof(Index));
        }


    }
}
