namespace GameSaleProject_Entity.Entities
{
    public class User : BaseEntity
	{
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        
        public string PhoneNumber { get; set; }
        
        //nav
        public ICollection<GameSale> GameSales { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
