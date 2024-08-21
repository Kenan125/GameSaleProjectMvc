namespace GameSaleProject_Entity.Entities
{
    public class GameSaleDetail : BaseEntity
	{
        
        public int GameSaleId { get; set; }
        public int GameId { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsRefunded { get; set; } = false;

        

        public virtual GameSale GameSale { get; set; }

        public virtual Game Game { get; set; }

    }
}
