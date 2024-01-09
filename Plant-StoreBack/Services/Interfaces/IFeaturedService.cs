using Plant_StoreBack.ViewModels.Banner;
using Plant_StoreBack.ViewModels.Featured;

namespace Plant_StoreBack.Services.Interfaces
{
    public interface IFeaturedService
    {
        Task<FeaturedVM> GetDataAsync();

    }
}
