using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Plant_StoreBack.Data;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels.Elementor;

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
    }
}
