using System.ComponentModel.DataAnnotations;

namespace GameSaleProject_Entity.Entities
{
    public class Game: BaseEntity
    {

        
        public string GameName { get; set; }

        
        public string Description { get; set; }

       
        public int Discount { get; set; }

        
        public decimal Price { get; set; }

        public string Developer { get; set; }

        
        public int PublisherId { get; set; } 

        
        public int CategoryId { get; set; } 

        public string Platform { get; set; }

        //Nav
        public virtual Publisher Publisher { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
