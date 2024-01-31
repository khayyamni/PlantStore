using Plant_StoreBack.ViewModels.Blog;
using Plant_StoreBack.ViewModels.Help;

namespace Plant_StoreBack.Services.Interfaces
{
    public interface IHelpsService
    {
        Task<HelpVM> GetDataAsync();
        Task<HelpVM> GetDataIdAsync(int id);
        Task EditAsync(HelpEditVM request);


    }
}
