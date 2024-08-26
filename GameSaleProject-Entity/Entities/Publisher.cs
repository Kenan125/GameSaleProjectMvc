using GameSaleProject_Entity.Identity;

namespace GameSaleProject_Entity.Entities
{
    public class Publisher : BaseEntity
    {


        public string Name { get; set; }
        public int? UserId { get; set; }

        public AppUser User { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}
