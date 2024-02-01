using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Plant_StoreBack.Data;
using Plant_StoreBack.Helpers.Extensions;
using Plant_StoreBack.Models;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels.Setting;

namespace Plant_StoreBack.Services
{
    public class SettingService : ISettingsService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;


        public SettingService(AppDbContext context, IMapper mapper, IWebHostEnvironment env)
        {
            _context = context;
            _mapper = mapper;
            _env = env;
        }

        public async Task<List<Setting>> GetAllAsync()
        {
            return await _context.Settings.ToListAsync();
        }


        public Dictionary<string, string> GetSettings()
        {
            return _context.Settings.Where(m => !m.SoftDeleted)
                                         .AsEnumerable()
                                         .ToDictionary(m => m.Key, m => m.Value);
        }

        public async Task<Setting> GetByIdAsync(int id)
        {
            return await _context.Settings.FirstOrDefaultAsync(m => m.Id == id);
        }



        public async Task EditAsync(SettingEditVM setting)
        {
            if (setting.Value.Contains("jpg") || setting.Value.Contains("png") || setting.Value.Contains("jpeg"))
            {
                string oldPath = _env.GetFilePath("assets/images", setting.Value);

                string fileName = $"{Guid.NewGuid()}-{setting.Photo.FileName}";

                string newPath = _env.GetFilePath("assets/images", fileName);

                Setting dbSetting = await _context.Settings.FirstOrDefaultAsync(m => m.Id == setting.Id);

                dbSetting.Value = fileName;
                _context.Settings.Update(dbSetting);
                await _context.SaveChangesAsync();

                if (File.Exists(oldPath))
                {
                    File.Delete(oldPath);
                }

                await setting.Photo.SaveFileAsync(newPath);
            }
            else
            {
                Setting dbSetting = await _context.Settings.FirstOrDefaultAsync(m => m.Id == setting.Id);

                _mapper.Map(setting, dbSetting);

                _context.Settings.Update(dbSetting);

                await _context.SaveChangesAsync();
            }
        }


    }
}
