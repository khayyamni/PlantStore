using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Plant_StoreBack.Data;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels.About;

namespace Plant_StoreBack.Services
{
    public class AboutService : IAboutService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public AboutService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<AboutVM> GetAllAsync()
        {
            return _mapper.Map<AboutVM>(await _context.Abouts.FirstOrDefaultAsync());
        }

        public async Task<AboutVM> GetByIdAsync(int id)
        {
            var datas = await _context.Abouts.FirstOrDefaultAsync(m => m.Id == id);
            AboutVM about = _mapper.Map<AboutVM>(datas);
            return about;
        }
    }
}
