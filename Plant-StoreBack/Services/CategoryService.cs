using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Plant_StoreBack.Data;
using Plant_StoreBack.Models;
using Plant_StoreBack.Services.Interfaces;

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

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.Include(m => m.Products).ToListAsync();
        }
    }
}
