using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Plant_StoreBack.Data;
using Plant_StoreBack.Helpers.Extensions;
using Plant_StoreBack.Models;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels.About;
using Plant_StoreBack.ViewModels.Blog;
using Plant_StoreBack.ViewModels.Company;

namespace Plant_StoreBack.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public CompanyService(AppDbContext context, IMapper mapper, IWebHostEnvironment env)
        {
            _context = context;
            _mapper = mapper;
            _env = env;
        }
              public async Task EditAsync(CompanyEditVM request)
        {
            string fileName;

            if (request.Photo is not null)
            {
                string oldPath = _env.GetFilePath("assets/images/about-page/company", request.Image);
                fileName = $"{Guid.NewGuid()}-{request.Photo.FileName}";
                string newPath = _env.GetFilePath("assets/images/about-page/company", fileName);

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

            Company dbCompany = await _context.Companies.FirstOrDefaultAsync(m => m.Id == request.Id);


            _mapper.Map(request, dbCompany);

            dbCompany.Image = fileName;

            _context.Companies.Update(dbCompany);

            await _context.SaveChangesAsync();
        }


        public async Task<CompanyVM> GetAllAsync()
        {
            return _mapper.Map<CompanyVM>(await _context.Companies.FirstOrDefaultAsync());
        }

        public async Task<CompanyVM> GetByIdAsync(int id)
        {
            var datas = await _context.Companies.FirstOrDefaultAsync(m => m.Id == id);
            CompanyVM company = _mapper.Map<CompanyVM>(datas);
            return company;
        }
    }
}
