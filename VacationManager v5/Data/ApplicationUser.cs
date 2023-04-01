using Microsoft.AspNetCore.Identity;

namespace VacationManager_v5.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Team { get; set; }
    }
}
