using Plant_StoreBack.ViewModels.Banner;
using Plant_StoreBack.ViewModels.Elementor;
using Plant_StoreBack.ViewModels.Help;

namespace Plant_StoreBack.Services.Interfaces
{
    public interface IElementorService
    {
        Task EditAsync(ElementorEditVM request);
        Task<List<ElementorVM>> GetAllAsync();
		Task<ElementorVM> GetDataIdAsync(int id);
	}
}
