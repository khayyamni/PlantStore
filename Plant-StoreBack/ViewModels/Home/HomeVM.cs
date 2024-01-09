using Plant_StoreBack.ViewModels.Banner;
using Plant_StoreBack.ViewModels.Elementor;

namespace Plant_StoreBack.ViewModels.Home
{
    public class HomeVM
    {
        public BannerVM Banner { get; set; }
        public List<ElementorVM> Elementors { get; set; }
    }
}
