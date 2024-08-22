
using GameSaleProject_Entity.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameSaleProject_Entity.Entities
{
    public class GameSale : BaseEntity
	{
        
        
        public int UserId { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsDiscountApplied { get; set; }
        public bool IsFullyRefunded { get; set; } = false;

        public virtual List<GameSaleDetail> GameSaleDetails { get; set; }

        
        public virtual AppUser User { get; set; }
    }
}
