using Microsoft.AspNetCore.Identity;

namespace Plant_StoreBack.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }

    }
}
