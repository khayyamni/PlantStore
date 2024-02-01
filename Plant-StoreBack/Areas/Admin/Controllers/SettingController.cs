﻿using Microsoft.AspNetCore.Mvc;
using Plant_StoreBack.Helpers.Extensions;
using Plant_StoreBack.Models;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels.Setting;

namespace Plant_StoreBack.Areas.Admin.Controllers
{
    public class SettingController : MainController
    {
        private readonly ISettingsService _settingService;

        public SettingController(ISettingsService settingService)
        {
            _settingService = settingService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _settingService.GetAllAsync());
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return RedirectToAction("Index", "Error");

            Setting setting = await _settingService.GetByIdAsync((int)id);

            if (setting is null) return RedirectToAction("Index", "Error");

            SettingEditVM model = new()
            {
                Key = setting.Key,
                Value = setting.Value
            };

            return View(model);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, SettingEditVM setting)
        {
            if (id is null) return RedirectToAction("Index", "Error");

            Setting dbSetting = await _settingService.GetByIdAsync((int)id);

            if (dbSetting is null) return RedirectToAction("Index", "Error");

            if (dbSetting.Value.Contains("png") || dbSetting.Value.Contains("jpeg") || dbSetting.Value.Contains("jpg"))
            {

                setting.Value = dbSetting.Value;
                setting.Key = dbSetting.Key;


                if (setting.Photo is null)
                {
                    return RedirectToAction(nameof(Index));
                }
                if (!setting.Photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photo", "File can be only image format");
                    return View(setting);
                }

                if (!setting.Photo.CheckFileSize(500))
                {
                    ModelState.AddModelError("Photo", "File size can be max 500 kb");
                    return View(setting);
                }

            }
            else
            {
                if (id is null) return RedirectToAction("Index", "Error");

                Setting dbsetting = await _settingService.GetByIdAsync((int)id);

                if (dbSetting is null) return RedirectToAction("Index", "Error");

                setting.Key = dbSetting.Key;


                if (!ModelState.IsValid)
                {
                    return View(setting);
                }

            }


            await _settingService.EditAsync(setting);

            return RedirectToAction(nameof(Index));
        }

    }
}
