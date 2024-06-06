using Microsoft.AspNetCore.Identity;

namespace Practice.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
