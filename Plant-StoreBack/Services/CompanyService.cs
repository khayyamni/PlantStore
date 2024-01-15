using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Plant_StoreBack.Data;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels.About;
using Plant_StoreBack.ViewModels.Company;

namespace Plant_StoreBack.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CompanyService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CompanyVM> GetAllAsync()
        {
            return _mapper.Map<CompanyVM>(await _context.Companies.FirstOrDefaultAsync());
        }

        public async Task<CompanyVM> GetByIdAsync(int id)
        {
            var datas = await _context.Abouts.FirstOrDefaultAsync(m => m.Id == id);
            CompanyVM company = _mapper.Map<CompanyVM>(datas);
            return company;
        }
    }
}
