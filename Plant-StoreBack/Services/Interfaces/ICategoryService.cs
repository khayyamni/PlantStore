using Plant_StoreBack.Models;
using Plant_StoreBack.ViewModels.Category;

namespace Plant_StoreBack.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryVM>> GetAllAsync();
        Task<CategoryVM> GetByNameWithoutTrackingAsync(string name);
        Task<CategoryVM> GetCategoryByIdAsync(int id);
        Task CreateAsync(CategoryCreateVM request);
        Task DeleteAsync(int id);
        Task EditAsync(CategoryEditVM request);
    }
}
