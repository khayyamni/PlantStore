using Plant_StoreBack.ViewModels.Blog;
using Plant_StoreBack.ViewModels.Elementor;

namespace Plant_StoreBack.Services.Interfaces
{
    public interface IBlogService
    {
        Task<List<BlogVM>> GetAllAsync();

    }
}
