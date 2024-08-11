using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        
        public virtual User Customer { get; set; }

        

    }
}
