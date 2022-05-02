using Microsoft.AspNetCore.Identity;

namespace UrbanDuck.Models
{
    public class UserRoles : IdentityRole
    {
        public const string Admin = "Admin";
        public const string User = "User";
    }
}
