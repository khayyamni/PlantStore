using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Plant_StoreBack.Data;
using Plant_StoreBack.Helpers.Extensions;
using Plant_StoreBack.Models;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels.Blog;
using Plant_StoreBack.ViewModels.Team;

namespace Plant_StoreBack.Services
{
    public class TeamService : ITeamService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public TeamService(AppDbContext context,
                           IMapper mapper,
                           IWebHostEnvironment env)
        {
            _context = context;
            _mapper = mapper;
            _env = env;

        }

        public async Task<List<TeamVM>> GetAllAsync()
        {
            return _mapper.Map<List<TeamVM>>(await _context.Teams.ToListAsync());
        }

        public async Task<TeamVM> GetByIdAsync(int id)
        {
            return _mapper.Map<TeamVM>(await _context.Teams.Where(m => m.Id == id).FirstOrDefaultAsync());
        }



        public async Task CreateAsync(TeamCreateVM request)
        {
            string fileName = $"{Guid.NewGuid()}-{request.Photo.FileName}";
            string path = _env.GetFilePath("assets/images/about-page/blog", fileName);

            var data = _mapper.Map<Team>(request);

            data.Image = fileName;

            await _context.Teams.AddAsync(data);
            await _context.SaveChangesAsync();
            await request.Photo.SaveFileAsync(path);
        }


        public async Task DeleteAsync(int id)
        {
            Team team = await _context.Teams.Where(m => m.Id == id).FirstOrDefaultAsync();
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();

            string path = _env.GetFilePath("assets/images/-about-page/blog", team.Image);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }


        public async Task EditAsync(TeamEditVM request)
        {
            string fileName;

            if (request.Photo is not null)
            {
                string oldPath = _env.GetFilePath("assets/images/about-page/blog", request.Image);
                fileName = $"{Guid.NewGuid()}-{request.Photo.FileName}";
                string newPath = _env.GetFilePath("assets/images/about-page/blog", fileName);

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

            Team dbTeam = await _context.Teams.FirstOrDefaultAsync(m => m.Id == request.Id);


            _mapper.Map(request, dbTeam);

            dbTeam.Image = fileName;

            _context.Teams.Update(dbTeam);

            await _context.SaveChangesAsync();
        }

    }
}
