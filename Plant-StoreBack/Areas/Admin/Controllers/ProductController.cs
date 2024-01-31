using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Plant_StoreBack.Helpers.Extensions;
using Plant_StoreBack.Services;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels.Blog;
using Plant_StoreBack.ViewModels.Product;

namespace Plant_StoreBack.Areas.Admin.Controllers
{
    public class ProductController : MainController
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _productService.GetAllAsync());

        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.categories = await GetCategoriesAsync();
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateVM request)
        {

            ViewBag.categories = await GetCategoriesAsync();

            if (!ModelState.IsValid)
            {
                return View(request);
            }

            ProductVM existProduct = await _productService.GetByNameWithoutTrackingAsync(request.Name);

            if (existProduct is not null)
            {
                ModelState.AddModelError("Name", "This name already exists");

                return View(request);
            }

            foreach (var photo in request.Photos)
            {

                if (!photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photos", "File can be only image format");
                    return View(request);
                }

                if (!photo.CheckFileSize(500))
                {
                    ModelState.AddModelError("Photos", "File size can be max 500 kb");
                    return View(request);
                }
            }


            await _productService.CreateAsync(request);
            return RedirectToAction(nameof(Index));

        }




		[HttpGet]
		public async Task<IActionResult> Edit(int? id)
		{
			ViewBag.categories = await GetCategoriesAsync();


			if (id is null) return RedirectToAction("Index", "Error");

			ProductDetailVM dbProduct = await _productService.GetByIdWithIncludesWithoutTrackingAsync((int)id);

			if (dbProduct is null) RedirectToAction("Index", "Error");

			return View(new ProductEditVM
			{
				Id = dbProduct.Id,
				Name = dbProduct.Name,
				Price = dbProduct.Price,
				Description = dbProduct.Description,
				CategoryId = dbProduct.CategoryId,
				Images = dbProduct.Images
			});
		}




		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, ProductEditVM request)
        {
            ViewBag.categories = await GetCategoriesAsync();

            if (id is null) return RedirectToAction("Index", "Error");

            ProductDetailVM dbProduct = await _productService.GetByIdWithIncludesWithoutTrackingAsync((int)id);

            if (dbProduct is null) return RedirectToAction("Index", "Error");

            request.Images = dbProduct.Images;

            if (!ModelState.IsValid)
            {
                return View(request);
            }

            ProductVM existProduct = await _productService.GetByNameWithoutTrackingAsync(request.Name);


            if (request.Photos != null)
            {
                foreach (var photo in request.Photos)
                {
                    if (!photo.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("Photos", "File can only be in image format");
                        return View(request);

                    }

                    if (!photo.CheckFileSize(500))
                    {
                        ModelState.AddModelError("Photos", "File size can be max 500 kb");
                        return View(request);
                    }
                }
            }


            if (existProduct is not null)
            {
                if (existProduct.Id == request.Id)
                {
                    await _productService.EditAsync(request);

                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("Name", "This name already exists");
                return View(request);
            }

            await _productService.EditAsync(request);

            return RedirectToAction(nameof(Index));

        }





        private async Task<SelectList> GetCategoriesAsync()
        {
            return new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


		public async Task<IActionResult> DeleteProductImage(int id)
		{
			await _productService.DeleteProductImageAsync(id);

			return Ok();
		}



		[HttpGet]
		public async Task<IActionResult> Detail(int? id)
		{
			if (id is null) return RedirectToAction("Index", "Error");

			ProductVM blog = await _productService.GetByIdAsync((int)id);

			if (blog is null) return RedirectToAction("Index", "Error");

			return View(blog);
		}


	}
}
