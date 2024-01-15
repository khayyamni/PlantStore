using Plant_StoreBack.Models;
using Plant_StoreBack.ViewModels.About;

namespace Plant_StoreBack.Services.Interfaces
{
    public interface IAboutService
    {
        Task<AboutVM> GetAllAsync();
        Task<AboutVM> GetByIdAsync(int id);
    }
}
