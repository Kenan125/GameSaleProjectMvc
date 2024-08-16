using Microsoft.AspNetCore.Identity;

namespace GameSaleProject_DataAccess.Identity
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePictureUrl { get; set; }

    }
}
