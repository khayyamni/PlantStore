using Plant_StoreBack.Models;
using Plant_StoreBack.ViewModels.Category;

namespace Plant_StoreBack.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryVM>> GetAllAsync();
        Task<CategoryVM> GetCategoryByIdAsync(int id);
        
    }
}
