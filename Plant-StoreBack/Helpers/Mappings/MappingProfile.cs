using AutoMapper;
using Plant_StoreBack.Models;
using System.Drawing.Drawing2D;
using System.Reflection.Metadata;
using System.Security.Cryptography.Pkcs;
using System;
using Plant_StoreBack.ViewModels.Banner;
using Plant_StoreBack.ViewModels.Elementor;

namespace Plant_StoreBack.Helpers.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Banner, BannerVM>().ReverseMap();
            CreateMap<Elementor, ElementorVM>().ReverseMap();

        }
    }
}

