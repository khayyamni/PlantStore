using Microsoft.AspNetCore.Cors.Infrastructure;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels;
using Plant_StoreBack.ViewModels.Shop;

namespace Plant_StoreBack.Services
{
    public class LayoutService : ILayoutService
    {
        private readonly ISettingsService _settingsService;
        private readonly IBasketService _basketService;
        private readonly IWishlistService _wishlistService;
        
        public LayoutService(ISettingsService settingService,
                             IBasketService basketService,
                             IWishlistService wishlistService)
        {
            _settingsService = settingService;
            _basketService = basketService;
            _wishlistService = wishlistService;
           
        }
        public HeaderVM GetHeaderDatas()
        {

            Dictionary<string, string> settingDatas = _settingsService.GetSettings();

            int basketCount = _basketService.GetCount();
            int wishlistCount = _wishlistService.GetCount();

            return new HeaderVM
            {
                Logo = settingDatas["HeaderLogo"],
                BasketCount = basketCount,
                WishlistCount = wishlistCount
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
