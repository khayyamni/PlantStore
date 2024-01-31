using Plant_StoreBack.Models;
using Plant_StoreBack.ViewModels.Product;

namespace Plant_StoreBack.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductVM>> GetAllAsync();
        Task<ProductVM> GetByIdAsync(int id);

        Task<ProductVM> GetByNameWithoutTrackingAsync(string name);

        Task CreateAsync(ProductCreateVM product);

        Task<List<ProductVM>> GetAllWithImagesByTakeAsync(int take);
        Task DeleteAsync(int id);
        Task EditAsync(ProductEditVM product);
        Task<ProductDetailVM> GetByIdWithIncludesWithoutTrackingAsync(int id);
        Task<Product> GetByIdWithIncludesAsync(int id);
		Task DeleteProductImageAsync(int id);

		Task<int> GetCountAsync();

        Task<List<ProductVM>> GetByCategoryAsync(int id);


        Task<List<ProductVM>> OrderByNameAsc();
        Task<List<ProductVM>> OrderByNameDesc();
        Task<List<ProductVM>> OrderByPriceAsc();
        Task<List<ProductVM>> OrderByPriceDesc();
        Task<List<ProductVM>> FilterAsync(int value1, int value2);
        Task<List<ProductVM>> SearchAsync(string searchText);
    }
}
