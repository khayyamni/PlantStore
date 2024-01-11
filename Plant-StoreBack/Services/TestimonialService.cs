using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Plant_StoreBack.Data;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels.Blog;
using Plant_StoreBack.ViewModels.Testimonial;

namespace Plant_StoreBack.Services
{
    public class TestimonialService : ITestimonialService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;


        public TestimonialService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<TestimonialVM>> GetAllAsync()
        {
            var test = await _context.Testimonials.ToListAsync();

            return _mapper.Map<List<TestimonialVM>>(test);
        }
    }
}
