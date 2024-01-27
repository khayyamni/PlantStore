using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Plant_StoreBack.Data;
using Plant_StoreBack.Models;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels.Product;

namespace Plant_StoreBack.Services
{
    public class ProductService : IProductService
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductService(AppDbContext context,
                              IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
    }
}
