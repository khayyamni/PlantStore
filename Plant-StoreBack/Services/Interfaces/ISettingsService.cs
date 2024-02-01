using Plant_StoreBack.Models;
using Plant_StoreBack.ViewModels.Setting;

namespace Plant_StoreBack.Services.Interfaces
{
    public interface ISettingsService
    {
        Dictionary<string, string> GetSettings();
        Task<List<Setting>> GetAllAsync();
        Task<Setting> GetByIdAsync(int id);
        Task EditAsync(SettingEditVM setting);
    }
}
