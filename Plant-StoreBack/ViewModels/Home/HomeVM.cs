using Plant_StoreBack.ViewModels.Banner;
using Plant_StoreBack.ViewModels.Blog;
using Plant_StoreBack.ViewModels.Elementor;
using Plant_StoreBack.ViewModels.Featured;

namespace Plant_StoreBack.ViewModels.Home
{
    public class HomeVM
    {
        public BannerVM Banner { get; set; }
        public List<ElementorVM> Elementors { get; set; }
        public List<BlogVM> Blogs { get; set; }
        public FeaturedVM Featured { get; set; }
    }
}
