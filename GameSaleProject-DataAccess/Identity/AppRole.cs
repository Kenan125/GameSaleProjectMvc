using Microsoft.AspNetCore.Identity;

namespace GameSaleProject_DataAccess.Identity
{
    public class AppRole : IdentityRole<int>
    {
        public DateTime CreatedDate { get; set; }= DateTime.Now;
        public string Description { get; set; }
    }
}
