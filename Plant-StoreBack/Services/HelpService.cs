using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Plant_StoreBack.Data;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels.Banner;
using Plant_StoreBack.ViewModels.Help;

namespace Plant_StoreBack.Services
{
    public class HelpService : IHelpsService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;


        public HelpService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
         public async Task<HelpVM> GetDataAsync()
        {
            var helps = await _context.Helps.FirstOrDefaultAsync();

            return _mapper.Map<HelpVM>(helps);
        }
    }
}
