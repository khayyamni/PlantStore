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



        public async Task CreateAsync(CategoryCreateVM request)
        {
         
            var data = _mapper.Map<Category>(request);
            await _context.Categories.AddAsync(data);
            await _context.SaveChangesAsync();
        }

        public async Task<CategoryVM> GetByNameWithoutTrackingAsync(string name)
        {

            return _mapper.Map<CategoryVM>(await _context.Categories.AsNoTracking()
                                                         .FirstOrDefaultAsync(m => m.Name.Trim().ToLower() == name.Trim().ToLower()));

        }



        public async Task DeleteAsync(int id)
        {
            Category category = await _context.Categories.Where(m => m.Id == id).FirstOrDefaultAsync();
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

        }




        public async Task EditAsync(CategoryEditVM request)
        {

            Category dbCategory = await _context.Categories.FirstOrDefaultAsync(m => m.Id == request.Id);


            _mapper.Map(request, dbCategory);

            _context.Categories.Update(dbCategory);

            await _context.SaveChangesAsync();
        }




    }
}
