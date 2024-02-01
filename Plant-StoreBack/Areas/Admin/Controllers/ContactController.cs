using Microsoft.AspNetCore.Mvc;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels.Contact;

namespace Plant_StoreBack.Areas.Admin.Controllers
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMessage(ContactCreateMessageVM request)
        {

            await _contactService.CreateAsync(request);

            return RedirectToAction("Index", "Contact");

        }


    }
}
