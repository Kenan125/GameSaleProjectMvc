using GameSaleProject_Entity.Entities;

namespace GameSaleProject_Entity.ViewModels
{
    public class GameSaleDetailViewModel
    {
        public int Id { get; set; }
        public int GameSaleId { get; set; }
        public int GameId { get; set; }
        public string GameName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Discount { get; set; }
        public bool IsRefunded { get; set; } = false;

        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual GameSale GameSale { get; set; }

        public virtual Game Game { get; set; }




    }
}
