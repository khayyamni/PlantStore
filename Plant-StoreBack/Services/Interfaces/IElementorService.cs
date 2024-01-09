using Plant_StoreBack.ViewModels.Banner;
using Plant_StoreBack.ViewModels.Elementor;

namespace Plant_StoreBack.Services.Interfaces
{
    public interface IElementorService
    {
        Task<List<ElementorVM>> GetAllAsync();

    }
}
