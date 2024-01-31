using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Plant_StoreBack.Data;
using Plant_StoreBack.Helpers.Extensions;
using Plant_StoreBack.Models;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels.Product;

namespace Plant_StoreBack.Services
{
    public class ProductService : IProductService
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;


        public ProductService(AppDbContext context,
                              IMapper mapper,
                              IWebHostEnvironment env)
        {
            _context = context;
            _mapper = mapper;
            _env = env;
        }
        public async Task<List<ProductVM>> GetAllAsync()
        {
            return _mapper.Map<List<ProductVM>>(await _context.Products.Include(m => m.Category).Include(m => m.Images).ToListAsync());
        }

        public async Task<ProductVM> GetByIdAsync(int id)
        {
            var data = await _context.Products.Include(m => m.Category).Include(m => m.Images).FirstOrDefaultAsync(m => m.Id == id);
            return _mapper.Map<ProductVM>(data);       
        }

        public async Task<List<ProductVM>> GetByCategoryAsync(int id)
        {
            return _mapper.Map<List<ProductVM>>(await _context.Products.Where(m => m.CategoryId == id).Include(m=>m.Category).Include(m=>m.Images).ToListAsync());
        }

        public async Task<List<ProductVM>> GetAllWithImagesByTakeAsync(int take)
        {
           return _mapper.Map<List<ProductVM>>(await _context.Products.Include(m => m.Images).Include(m=>m.Category).Take(take).ToListAsync());

        }



        public async Task<Product> GetByIdWithIncludesAsync(int id)
        {
            return await _context.Products
                           .Where(m => m.Id == id)
                           .Include(m => m.Images)
                           .Include(m => m.Category)
                           .FirstOrDefaultAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.Products.CountAsync();
        }



        public async Task<List<ProductVM>> OrderByNameAsc()
        {
            var dbProducts = await _context.Products.Include(m => m.Images)
                                                                            .OrderBy(p => p.Name)
                                                                            .ToListAsync();
            return _mapper.Map<List<ProductVM>>(dbProducts);
        }

        public async Task<List<ProductVM>> OrderByNameDesc()
        {
            var dbProducts = await _context.Products.Include(m => m.Images)
                                                                            .OrderByDescending(p => p.Name)
                                                                            .ToListAsync();
            return _mapper.Map<List<ProductVM>>(dbProducts);
        }

        public async Task<List<ProductVM>> OrderByPriceAsc()
        {
            var dbProducts = await _context.Products.Include(m => m.Images)
                                                                            .OrderBy(p => p.Price)
                                                                            .ToListAsync();
            return _mapper.Map<List<ProductVM>>(dbProducts);
        }

        public async Task<List<ProductVM>> OrderByPriceDesc()
        {
            var dbProducts = await _context.Products.Include(m => m.Images)
                                                                            .OrderByDescending(p => p.Price)
                                                                            .ToListAsync();
            return _mapper.Map<List<ProductVM>>(dbProducts);
        }

        public async Task<List<ProductVM>> FilterAsync(int value1, int value2)
        {
            List<Product> products = await _context.Products.Include(m => m.Images).Where(x => x.Price >= value1 && x.Price <= value2).ToListAsync();
            return _mapper.Map<List<ProductVM>>(products);
        }

        public async Task<List<ProductVM>> SearchAsync(string searchText)
        {
            var dbProducts = await _context.Products.Include(m => m.Images)
                                                 .Include(m => m.Category)
                                                 .OrderByDescending(m => m.Id)
                                                 .Where(m => m.Name.ToLower().Trim().Contains(searchText.ToLower().Trim()))
                                                 .ToListAsync();

            return _mapper.Map<List<ProductVM>>(dbProducts);
        }






        public async Task CreateAsync(ProductCreateVM product)
        {
            List<ProductImage> newImages = new();

            foreach (var photo in product.Photos)
            {
                string fileName = $"{Guid.NewGuid()}-{photo.FileName}";

                string path = _env.GetFilePath("assets/images/product", fileName);

                await photo.SaveFileAsync(path);

                newImages.Add(new ProductImage { Image = fileName });
            }

            newImages.FirstOrDefault().IsMain = true;

            await _context.ProductImages.AddRangeAsync(newImages);

            await _context.Products.AddAsync(new Product
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                CategoryId = product.CategoryId,
                Images = newImages
            });

            await _context.SaveChangesAsync();
        }




        public async Task<ProductVM> GetByNameWithoutTrackingAsync(string name)
        {
            return _mapper.Map<ProductVM>(await _context.Products.AsNoTracking()
                                                         .FirstOrDefaultAsync(m => m.Name.Trim().ToLower() == name.Trim().ToLower()));

        }



        public async Task DeleteAsync(int id)
        {
            Product dbProduct = await _context.Products.Include(m => m.Images).FirstOrDefaultAsync(m => m.Id == id);

            _context.Products.Remove(dbProduct);

            await _context.SaveChangesAsync();

            foreach (var item in dbProduct.Images)
            {
                string path = _env.GetFilePath("assets/images/product", item.Image);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

            }
        }


        public async Task DeleteProductImageAsync(int id)
        {
            ProductImage productImage = await _context.ProductImages.Where(m => m.Id == id).FirstOrDefaultAsync();

            _context.Remove(productImage);

            await _context.SaveChangesAsync();

            string path = _env.GetFilePath("assets/images/product", productImage.Image);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public async Task<ProductDetailVM> GetByIdWithIncludesWithoutTrackingAsync(int id)
        {
            Product dbProduct = await _context.Products.AsNoTracking()
                                                      .Include(m => m.Images)
                                                      .Include(m => m.Category)
                                                      .FirstOrDefaultAsync(m => m.Id == id);

            return _mapper.Map<ProductDetailVM>(dbProduct);
        }

        public async Task EditAsync(ProductEditVM product)
        {
            List<ProductImage> newImages = new();

            if (product.Photos != null)
            {
                foreach (var photo in product.Photos)
                {
                    string fileName = $"{Guid.NewGuid()} - {photo.FileName}";

                    string path = _env.GetFilePath("assets/images/product", fileName);

                    await photo.SaveFileAsync(path);

                    newImages.Add(new ProductImage { Image = fileName });
                }

                await _context.ProductImages.AddRangeAsync(newImages);
            }

            newImages.AddRange(product.Images);


            Product dbProduct = await _context.Products.FirstOrDefaultAsync(m => m.Id == product.Id);

            product.Images = newImages;

            _mapper.Map(product, dbProduct);

            _context.Products.Update(dbProduct);

            await _context.SaveChangesAsync();
        }
    }
}
