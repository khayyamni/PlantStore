using Plant_StoreBack.Models;

namespace Plant_StoreBack.Services.Interfaces
{
    public interface ISettingsService
    {
        Dictionary<string, string> GetSettings();

    }
}
