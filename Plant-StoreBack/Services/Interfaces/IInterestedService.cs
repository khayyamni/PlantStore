using Plant_StoreBack.ViewModels.Banner;
using Plant_StoreBack.ViewModels.Interested;

namespace Plant_StoreBack.Services.Interfaces
{
    public interface IInterestedService
    {
        Task<InterestedVM> GetDataAsync();
        Task<InterestedVM> GetDataIdAsync(int id);
        Task EditAsync(InterestedEditVM request);


    }
}
