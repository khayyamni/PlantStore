using Plant_StoreBack.ViewModels.About;
using Plant_StoreBack.ViewModels.Company;

namespace Plant_StoreBack.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<CompanyVM> GetAllAsync();
        Task<CompanyVM> GetByIdAsync(int id);
    }
}
