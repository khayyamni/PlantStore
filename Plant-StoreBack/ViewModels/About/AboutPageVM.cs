using Plant_StoreBack.ViewModels.Company;
using Plant_StoreBack.ViewModels.Team;
using System;

namespace Plant_StoreBack.ViewModels.About
{
    public class AboutPageVM
    {
        public AboutVM About { get; set; }
        public List<TeamVM> Teams { get; set; }
        public CompanyVM Company { get; set; }
    }
}
