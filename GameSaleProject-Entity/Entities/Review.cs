using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameSaleProject_Entity.Entities
{
    public class Review : BaseEntity
	{
        
        public int GameId { get; set; }
        public int CustomerId { get; set; }


        [Required] // Rating zorunlu alan
        public int Rating { get; set; }
        public string CustomerReview { get; set; }
        


        [ForeignKey("GameId")]
        public Game Game { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
    }
}
