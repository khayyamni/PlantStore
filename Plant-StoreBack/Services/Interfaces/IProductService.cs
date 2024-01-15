using Plant_StoreBack.Models;
using Plant_StoreBack.ViewModels.Product;

namespace Plant_StoreBack.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductVM>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);

        Task<List<ProductVM>> GetAllWithImagesByTakeAsync(int take);

        Task<Product> GetByIdWithIncludesAsync(int id);
        Task<int> GetCountAsync();



    }
}
