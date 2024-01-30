using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Plant_StoreBack.Data;
using Plant_StoreBack.Helpers.Extensions;
using Plant_StoreBack.Models;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels.Banner;
using Plant_StoreBack.ViewModels.Team;

namespace Plant_StoreBack.Services
{
    public class BannerService : IBannerService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;



        public BannerService(AppDbContext context, IMapper mapper , IWebHostEnvironment env)
        {
            _context = context;
            _mapper = mapper;
            _env = env;
        }
        public async Task<BannerVM> GetDataAsync()
        {
            var banner = await _context.Banners.FirstOrDefaultAsync();

            return _mapper.Map<BannerVM>(banner);
        }


		

		public async Task<BannerVM> GetDataIdAsync(int id)
		{
			Banner data = await _context.Banners.FirstOrDefaultAsync(m => m.Id == id);
			return _mapper.Map<BannerVM>(data);
		}


        public async Task EditAsync(BannerEditVM request)
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

            Banner dbBanner = await _context.Banners.FirstOrDefaultAsync(m => m.Id == request.Id);


            _mapper.Map(request, dbBanner);

            dbBanner.Image = fileName;

            _context.Banners.Update(dbBanner);

            await _context.SaveChangesAsync();
        }


    }
}
