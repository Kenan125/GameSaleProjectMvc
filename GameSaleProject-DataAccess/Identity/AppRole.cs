using Microsoft.AspNetCore.Identity;

namespace GameSaleProject_DataAccess.Identity
{
    public class AppRole : IdentityRole<int>
    {
        public string Description { get; set; }
    }
}
