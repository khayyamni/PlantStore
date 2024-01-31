using Plant_StoreBack.ViewModels.Banner;
using Plant_StoreBack.ViewModels.Blog;
using Plant_StoreBack.ViewModels.Elementor;

namespace Plant_StoreBack.Services.Interfaces
{
    public interface IBlogService
    {
        Task<List<BlogVM>> GetAllAsync();
		Task<BlogVM> GetDataIdAsync(int id);
        Task EditAsync(BlogEditVM request);
        Task<BlogVM> GetDataAsync();
        Task CreateAsync(BlogCreateVM request);
        Task DeleteAsync(int id);

    }
}
