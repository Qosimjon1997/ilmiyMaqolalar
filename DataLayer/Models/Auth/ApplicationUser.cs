using Microsoft.AspNetCore.Identity;

namespace DataLayer.Models.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public string FIO { get; set; }
        public string RoleName { get; set; }

    }
}
