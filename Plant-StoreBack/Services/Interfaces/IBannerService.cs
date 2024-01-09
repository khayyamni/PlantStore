using Plant_StoreBack.Models;
using Plant_StoreBack.ViewModels.Banner;

namespace Plant_StoreBack.Services.Interfaces
{
    public interface IBannerService
    {
        Task<BannerVM> GetDataAsync();

    }
}
