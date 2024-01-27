using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Plant_StoreBack.Data;
using Plant_StoreBack.Models;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels.Contact;
using Plant_StoreBack.ViewModels.ContactMessage;
using System.Security.Cryptography.Pkcs;

namespace Plant_StoreBack.Services
{
    public class ContactService : IContactService
    {
        private readonly AppDbContext _context;
        private readonly ISettingsService _settingService;
        private readonly IMapper _mapper;


        public ContactService(AppDbContext context, IMapper mapper, ISettingsService settingService)
        {
            _context = context;
            _mapper = mapper;
            _settingService = settingService;
        }
        public  ContactVM GetData()
        {
            
            Dictionary<string, string> settingDatas = _settingService.GetSettings();

            ContactVM model = new()
            {
                Email = settingDatas["Email"],
                Phone1 = settingDatas["Phone1"],
                Phone2 = settingDatas["Phone2"],
                Address = settingDatas["Address"]
            };

            return model;
        }


        public async Task<List<ContactMessageVM>> GetAllMessagesAsync()
        {
            return _mapper.Map<List<ContactMessageVM>>(await _context.ContactMessages.ToListAsync());
        }

        public async Task<ContactMessageVM> GetMessageByIdAsync(int id)
        {
            var datas = await _context.ContactMessages.FirstOrDefaultAsync(m => m.Id == id);
            ContactMessageVM contactMessage = _mapper.Map<ContactMessageVM>(datas);
            return contactMessage;
        }

    }

}
