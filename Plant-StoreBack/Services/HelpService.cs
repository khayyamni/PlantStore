using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Plant_StoreBack.Data;
using Plant_StoreBack.Models;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels.Banner;
using Plant_StoreBack.ViewModels.Blog;
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

        public async Task EditAsync(HelpEditVM request)
        {
            Help dbHelp= await _context.Helps.FirstOrDefaultAsync(m => m.Id == request.Id);


            _mapper.Map(request, dbHelp);

            

            _context.Helps.Update(dbHelp);

            await _context.SaveChangesAsync();
        }

        public async Task<HelpVM> GetDataAsync()
        {
            var helps = await _context.Helps.FirstOrDefaultAsync();

            return _mapper.Map<HelpVM>(helps);
        }

		public async Task<HelpVM> GetDataIdAsync(int id)
		{
			Help data = await _context.Helps.FirstOrDefaultAsync(m => m.Id == id);
			return _mapper.Map<HelpVM>(data);
		}



        


	}
}
