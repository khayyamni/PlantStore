using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Plant_StoreBack.Data;
using Plant_StoreBack.Models;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels.Category;

namespace Plant_StoreBack.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CategoryService(AppDbContext context,
                            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CategoryVM>> GetAllAsync()
        {

             var data = await _context.Categories.Include(m => m.Products).ToListAsync();
            return _mapper.Map<List<CategoryVM>>(data);
        }

        public async Task<CategoryVM> GetCategoryByIdAsync(int id)
        {
            var data = await _context.Categories.Where(m => m.Id == id).Include(m=>m.Products).FirstOrDefaultAsync();
            return _mapper.Map<CategoryVM>(data);
        }
    }
}
