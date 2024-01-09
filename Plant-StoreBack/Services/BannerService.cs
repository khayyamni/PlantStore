using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Plant_StoreBack.Data;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels.Banner;

namespace Plant_StoreBack.Services
{
    public class BannerService : IBannerService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;


        public BannerService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<BannerVM> GetDataAsync()
        {
            var banner = await _context.Banners.FirstOrDefaultAsync();

            return _mapper.Map<BannerVM>(banner);
        }
    }
}
