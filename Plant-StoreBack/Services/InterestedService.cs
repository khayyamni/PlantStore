using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Plant_StoreBack.Data;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels.Banner;
using Plant_StoreBack.ViewModels.Interested;

namespace Plant_StoreBack.Services
{
    public class InterestedService : IInterestedService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public InterestedService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<InterestedVM> GetDataAsync()
        {
            var interested = await _context.interesteds.FirstOrDefaultAsync();

            return _mapper.Map<InterestedVM>(interested);
        }
    }
}
