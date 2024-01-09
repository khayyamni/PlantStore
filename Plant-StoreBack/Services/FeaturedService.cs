using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Plant_StoreBack.Data;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels.Banner;
using Plant_StoreBack.ViewModels.Featured;

namespace Plant_StoreBack.Services
{
    public class FeaturedService:IFeaturedService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;


        public FeaturedService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<FeaturedVM> GetDataAsync()
        {
            var featured = await _context.Featureds.FirstOrDefaultAsync();

            return _mapper.Map<FeaturedVM>(featured);
        }
    }
}
