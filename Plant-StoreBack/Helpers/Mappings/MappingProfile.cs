using AutoMapper;
using Plant_StoreBack.Models;
using System.Drawing.Drawing2D;
using System.Reflection.Metadata;
using System.Security.Cryptography.Pkcs;
using System;
using Plant_StoreBack.ViewModels.Banner;
using Plant_StoreBack.ViewModels.Elementor;
using Plant_StoreBack.ViewModels.Blog;
using Plant_StoreBack.ViewModels.Featured;
using Plant_StoreBack.ViewModels.Help;
using Plant_StoreBack.ViewModels.Interested;
using Plant_StoreBack.ViewModels.Category;
using Plant_StoreBack.ViewModels.Product;

namespace Plant_StoreBack.Helpers.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Product, ProductVM>().ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                                           .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Images.FirstOrDefault(m => m.IsMain).Image));

            CreateMap<Banner, BannerVM>().ReverseMap();
            CreateMap<Elementor, ElementorVM>().ReverseMap();
            CreateMap<Blog, BlogVM>().ReverseMap();
            CreateMap<Featured, FeaturedVM>().ReverseMap();
            CreateMap<Help, HelpVM>().ReverseMap();
            CreateMap<Interested, InterestedVM>().ReverseMap();
            CreateMap<Category, CategoryVM>();



        }
    }
}

