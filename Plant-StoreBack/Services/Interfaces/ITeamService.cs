using Plant_StoreBack.Models;
using Plant_StoreBack.ViewModels.Team;

namespace Plant_StoreBack.Services.Interfaces
{
    public interface ITeamService
    {
        Task CreateAsync(TeamCreateVM request);
        Task DeleteAsync(int id);
        Task EditAsync(TeamEditVM request);
        Task<List<TeamVM>> GetAllAsync();
        Task<TeamVM> GetByIdAsync(int id);
    }
}
