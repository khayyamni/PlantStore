using Microsoft.AspNetCore.Mvc;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels.Contact;

namespace Plant_StoreBack.Controllers
{
    public class ContactController : Controller
    {
        private readonly ISettingsService _settingService;
        private readonly IContactService _contactService;

        public ContactController(ISettingsService settingService, IContactService contactService)
        {
            _settingService = settingService;
            _contactService = contactService;
        }
        public async Task<IActionResult> Index()
        {
            ContactVM contact = await _contactService.GetData();

            ContactPageVM model = new()
            {
                Contact = contact
            };

            return View(model);
        }
    }
}
