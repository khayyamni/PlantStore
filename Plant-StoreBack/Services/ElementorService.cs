using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Plant_StoreBack.Data;
using Plant_StoreBack.Models;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels.Elementor;
using Plant_StoreBack.ViewModels.Help;

namespace Plant_StoreBack.Services
{
    public class ElementorService : IElementorService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;


        public ElementorService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ElementorVM>> GetAllAsync()
        {
            var elements = await _context.Elementors.ToListAsync();

            return _mapper.Map<List<ElementorVM>>(elements);
        }


		public async Task<ElementorVM> GetDataIdAsync(int id)
		{
			Elementor data = await _context.Elementors.FirstOrDefaultAsync(m => m.Id == id);
			return _mapper.Map<ElementorVM>(data);
		}


        public async Task EditAsync(ElementorEditVM request)
        {
            Elementor dbElementor = await _context.Elementors.FirstOrDefaultAsync(m => m.Id == request.Id);


            _mapper.Map(request, dbElementor);



            _context.Elementors.Update(dbElementor);

            await _context.SaveChangesAsync();
        }



    }
}
