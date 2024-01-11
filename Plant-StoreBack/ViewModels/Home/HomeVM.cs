using Plant_StoreBack.ViewModels.Banner;
using Plant_StoreBack.ViewModels.Blog;
using Plant_StoreBack.ViewModels.Elementor;
using Plant_StoreBack.ViewModels.Featured;
using Plant_StoreBack.ViewModels.Help;
using Plant_StoreBack.ViewModels.Interested;
using Plant_StoreBack.ViewModels.Product;
using Plant_StoreBack.ViewModels.Testimonial;

namespace Plant_StoreBack.ViewModels.Home
{
    public class HomeVM
    {
        public BannerVM Banner { get; set; }
        public List<ElementorVM> Elementors { get; set; }
        public List<BlogVM> Blogs { get; set; }
        public FeaturedVM Featured { get; set; }
        public HelpVM Help { get; set; }
        public InterestedVM Interested { get; set; }
        public List<ProductVM> Product { get; set; }
        public List<TestimonialVM> Testimonial { get; set; }
    }
}
