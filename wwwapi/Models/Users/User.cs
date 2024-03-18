using Microsoft.AspNetCore.Identity;
using wwwapi.Enums;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace wwwapi.Models.Users
{
    public class User : IdentityUser
    {
        public Role Role { get; set; }
    }
}
