using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Plant_StoreBack.Data;
using Plant_StoreBack.Helpers.Extensions;
using Plant_StoreBack.Models;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels.Banner;
using Plant_StoreBack.ViewModels.Blog;
using Plant_StoreBack.ViewModels.Interested;

namespace Plant_StoreBack.Services
{
    public class InterestedService : IInterestedService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public InterestedService(AppDbContext context, IMapper mapper, IWebHostEnvironment env)
        {
            _context = context;
            _mapper = mapper;
            _env = env;

        }
        public async Task<InterestedVM> GetDataAsync()
        {
            var data = await _context.interesteds.FirstOrDefaultAsync();

            return _mapper.Map<InterestedVM>(data);
        }


		public async Task<InterestedVM> GetDataIdAsync(int id)
		{
			Interested data = await _context.interesteds.FirstOrDefaultAsync(m => m.Id == id);
			return _mapper.Map<InterestedVM>(data);
		}



        public async Task EditAsync(InterestedEditVM request)
        {
            string fileName;

            if (request.Photo is not null)
            {
                string oldPath = _env.GetFilePath("assets/images", request.Image);
                fileName = $"{Guid.NewGuid()}-{request.Photo.FileName}";
                string newPath = _env.GetFilePath("assets/images", fileName);

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

            Interested dbInterested = await _context.interesteds.FirstOrDefaultAsync(m => m.Id == request.Id);


            _mapper.Map(request, dbInterested);

            dbInterested.Image = fileName;

            _context.interesteds.Update(dbInterested);

            await _context.SaveChangesAsync();
        }




    }
}
