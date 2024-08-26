
using GameSaleProject_Entity.Identity;

namespace GameSaleProject_Entity.Entities
{
    public class Review : BaseEntity
    {

        public int GameId { get; set; }
        public int CustomerId { get; set; }

        public int Rating { get; set; }
        public string CustomerReview { get; set; }


        //Nav
        public virtual Game Game { get; set; }

        public virtual AppUser User { get; set; }



    }
}
