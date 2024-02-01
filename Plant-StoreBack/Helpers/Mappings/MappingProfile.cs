using AutoMapper;
using Plant_StoreBack.Models;
using Plant_StoreBack.ViewModels.About;
using Plant_StoreBack.ViewModels.Banner;
using Plant_StoreBack.ViewModels.Blog;
using Plant_StoreBack.ViewModels.Category;
using Plant_StoreBack.ViewModels.Company;
using Plant_StoreBack.ViewModels.Contact;
using Plant_StoreBack.ViewModels.ContactMessage;
using Plant_StoreBack.ViewModels.Elementor;
using Plant_StoreBack.ViewModels.Featured;
using Plant_StoreBack.ViewModels.Help;
using Plant_StoreBack.ViewModels.Interested;
using Plant_StoreBack.ViewModels.Product;
using Plant_StoreBack.ViewModels.Team;
using Plant_StoreBack.ViewModels.Testimonial;

namespace Plant_StoreBack.Helpers.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Product, ProductVM>().ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                                           .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Images.FirstOrDefault(m => m.IsMain).Image));

            CreateMap<Product, ProductDetailVM>().ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                              .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images));

            CreateMap<ProductCreateVM, Product>().ReverseMap();
            CreateMap<ProductEditVM, Product>();
            CreateMap<Banner, BannerVM>().ReverseMap();
            CreateMap<Elementor, ElementorVM>().ReverseMap();
            CreateMap<Blog, BlogVM>().ReverseMap();
            CreateMap<BlogVM, BlogEditVM>();
            CreateMap<BlogEditVM, Blog>();
            CreateMap<BlogCreateVM, Blog>();
            CreateMap<Featured, FeaturedVM>().ReverseMap();
            CreateMap<Help, HelpVM>().ReverseMap();
            CreateMap<HelpVM, HelpEditVM>().ReverseMap();
            CreateMap<HelpEditVM, Help>();
            CreateMap<Interested, InterestedVM>().ReverseMap();
            CreateMap<InterestedVM, InterestedEditVM>();
            CreateMap<InterestedEditVM, Interested>();
            CreateMap<Category, CategoryVM>();
            CreateMap<Testimonial, TestimonialVM>();
            CreateMap<TestimonialCreateVM, Testimonial>();
            CreateMap<TestimonialVM, TestimonialEditVM>().ReverseMap();
            CreateMap<TestimonialEditVM, Testimonial>();
            CreateMap<About, AboutVM>().ReverseMap();
            CreateMap<AboutVM, AboutEditVM>().ReverseMap();
            CreateMap<AboutEditVM, About>();
            CreateMap<Team, TeamVM>();
            CreateMap<TeamCreateVM, Team>();
            CreateMap<TeamEditVM, Team>();
            CreateMap<TeamVM, TeamEditVM>();
            CreateMap<Company, CompanyVM>();
            CreateMap<CompanyEditVM, CompanyVM>().ReverseMap();
            CreateMap<CompanyEditVM, Company>().ReverseMap();
            CreateMap<ContactMessage, ContactMessageVM>().ReverseMap();
            CreateMap<ContactVM, ContactMessageVM>().ReverseMap();
            CreateMap<BannerVM, BannerEditVM>().ReverseMap();
            CreateMap<BannerEditVM,Banner>().ReverseMap();
            

        }
    }
}

