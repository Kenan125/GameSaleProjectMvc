using GameSaleProject_Entity.Entities;
using Microsoft.AspNetCore.Identity;

namespace GameSaleProject_Entity.Identity
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ProfilePictureUrl { get; set; }

        public ICollection<GameSale> GameSales { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
