using Plant_StoreBack.ViewModels.Help;

namespace Plant_StoreBack.Services.Interfaces
{
    public interface IHelpsService
    {
        Task<HelpVM> GetDataAsync();

    }
}
