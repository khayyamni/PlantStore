using Plant_StoreBack.Models;

namespace Plant_StoreBack.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllAsync();

    }
}
