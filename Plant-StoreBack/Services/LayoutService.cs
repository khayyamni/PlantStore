using Microsoft.AspNetCore.Cors.Infrastructure;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels;

namespace Plant_StoreBack.Services
{
    public class LayoutService : ILayoutService
    {
        private readonly ISettingsService _settingsService;
        
        public LayoutService(ISettingsService settingService)
        {
            _settingsService = settingService;
           
        }
        public HeaderVM GetHeaderDatas()
        {

            Dictionary<string, string> settingDatas = _settingsService.GetSettings();
           

            return new HeaderVM
            {
                Logo = settingDatas["HeaderLogo"]
            };
        }


        public FooterVM GetFooterDatas()
        {
            Dictionary<string, string> settingDatas = _settingsService.GetSettings();

            return new FooterVM
            {
                Logo = settingDatas["FooterLogo"]
            };
        }
    }
}
