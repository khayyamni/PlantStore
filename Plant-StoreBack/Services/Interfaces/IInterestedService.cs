using Plant_StoreBack.ViewModels.Interested;

namespace Plant_StoreBack.Services.Interfaces
{
    public interface IInterestedService
    {
        Task<InterestedVM> GetDataAsync();

    }
}
