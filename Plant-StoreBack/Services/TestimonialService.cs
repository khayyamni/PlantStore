using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Plant_StoreBack.Data;
using Plant_StoreBack.Helpers.Extensions;
using Plant_StoreBack.Models;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels.Blog;
using Plant_StoreBack.ViewModels.Testimonial;

namespace Plant_StoreBack.Services
{
    public class TestimonialService : ITestimonialService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
		private readonly IWebHostEnvironment _env;


		public TestimonialService(AppDbContext context, IMapper mapper, IWebHostEnvironment env)
		{
			_context = context;
			_mapper = mapper;
			_env = env;
		}
		public async Task<List<TestimonialVM>> GetAllAsync()
        {
            var test = await _context.Testimonials.ToListAsync();

            return _mapper.Map<List<TestimonialVM>>(test);
        }


		public async Task<TestimonialVM> GetDataIdAsync(int id)
		{
			Testimonial data = await _context.Testimonials.FirstOrDefaultAsync(m => m.Id == id);
			return _mapper.Map<TestimonialVM>(data);
		}


		public async Task CreateAsync(TestimonialCreateVM request)
		{
			string fileName = $"{Guid.NewGuid()}-{request.Photo.FileName}";
			string path = _env.GetFilePath("assets/images/testimonials", fileName);

			var data = _mapper.Map<Testimonial>(request);

			data.Image = fileName;

			await _context.Testimonials.AddAsync(data);
			await _context.SaveChangesAsync();
			await request.Photo.SaveFileAsync(path);
		}

		public async Task DeleteAsync(int id)
		{
			Testimonial testimonial = await _context.Testimonials.Where(m => m.Id == id).FirstOrDefaultAsync();
			_context.Testimonials.Remove(testimonial);
			await _context.SaveChangesAsync();

			string path = _env.GetFilePath("assets/images/testimonials", testimonial.Image);

			if (File.Exists(path))
			{
				File.Delete(path);
			}
		}



        public async Task EditAsync(TestimonialEditVM request)
        {
            string fileName;

            if (request.Photo is not null)
            {
                string oldPath = _env.GetFilePath("assets/images/testimonials", request.Image);
                fileName = $"{Guid.NewGuid()}-{request.Photo.FileName}";
                string newPath = _env.GetFilePath("assets/images/testimonials", fileName);

                if (File.Exists(oldPath))
                {
                    File.Delete(oldPath);
                }

                await request.Photo.SaveFileAsync(newPath);

            }
            else
            {
                fileName = request.Image;
            }

            Testimonial dbTestimonial = await _context.Testimonials.FirstOrDefaultAsync(m => m.Id == request.Id);


            _mapper.Map(request, dbTestimonial);

            dbTestimonial.Image = fileName;

            _context.Testimonials.Update(dbTestimonial);

            await _context.SaveChangesAsync();
        }



    }
}
