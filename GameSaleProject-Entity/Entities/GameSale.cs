using System.ComponentModel.DataAnnotations.Schema;

namespace GameSaleProject_Entity.Entities
{
    public class GameSale : BaseEntity
	{
        
        
        public int UserId { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsDiscountApplied { get; set; }


        public virtual List<GameSaleDetail> GameSaleDetails { get; set; }

        
        public virtual User User { get; set; }
    }
}
