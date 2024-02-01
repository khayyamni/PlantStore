using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Plant_StoreBack.Services.Interfaces;

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
	}
}
