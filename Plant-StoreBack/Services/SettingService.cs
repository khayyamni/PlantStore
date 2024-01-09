using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Plant_StoreBack.Data;
using Plant_StoreBack.Models;
using Plant_StoreBack.Services.Interfaces;

namespace Plant_StoreBack.Services
{
    public class SettingService : ISettingsService
    {
        private readonly AppDbContext _context;
       
        public SettingService(AppDbContext context)
        {
            _context = context;
            
        }

        public Dictionary<string, string> GetSettings()
        {
            return _context.Settings.AsEnumerable().ToDictionary(m => m.Key, m => m.Value);
        }
    }
}
