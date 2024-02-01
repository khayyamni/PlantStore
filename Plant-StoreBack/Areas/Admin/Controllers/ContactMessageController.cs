﻿using Microsoft.AspNetCore.Mvc;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels.Contact;
using Plant_StoreBack.ViewModels.ContactMessage;

namespace Plant_StoreBack.Areas.Admin.Controllers
{
    public class ContactMessageController : MainController
    {
        private readonly IContactService _contactService;
        public ContactMessageController(IContactService contactService)
        {
            _contactService = contactService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _contactService.GetAllMessagesAsync());
        }


        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return RedirectToAction("Index", "Error");

            ContactMessageVM dbMessage = await _contactService.GetMessageByIdAsync((int)id);

            if (dbMessage is null) return RedirectToAction("Index", "Error");

            return View(dbMessage);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _contactService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }



    }
}
