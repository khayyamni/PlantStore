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
        public  IActionResult Index()
        {
            ContactVM contact = _contactService.GetData();

            ContactPageVM model = new()
            {
                Contact = contact
            };

            return View(model);
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
