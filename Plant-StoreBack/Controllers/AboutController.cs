using Microsoft.AspNetCore.Mvc;
using Plant_StoreBack.Services.Interfaces;
using Plant_StoreBack.ViewModels.About;
using Plant_StoreBack.ViewModels.Company;
using Plant_StoreBack.ViewModels.Interested;
using Plant_StoreBack.ViewModels.Team;
using System;

namespace Plant_StoreBack.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly ITeamService _teamService;
        private readonly ICompanyService _companyService;
        private readonly IInterestedService _interestedService;
        public AboutController(IAboutService aboutService,
                               ITeamService teamService,
                               ICompanyService companyService,
                               IInterestedService interestedService)
        {
            _aboutService = aboutService;
            _teamService = teamService;
            _companyService = companyService;
            _interestedService = interestedService; 
        }
        public async Task<IActionResult> Index()
        {
            AboutVM about = await _aboutService.GetAllAsync();
            List<TeamVM> teams = await _teamService.GetAllAsync();
            CompanyVM company = await _companyService.GetAllAsync();
            InterestedVM interested = await _interestedService.GetDataAsync();

            AboutPageVM model = new()
            {
                About = about,
                Teams = teams,
                Company = company,
                Interested = interested
            };

            return View(model);
        }
    }
}
