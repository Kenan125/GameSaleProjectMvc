namespace GameSaleProject_Entity.ViewModels
{
    public class ReviewViewModel
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int CustomerId { get; set; }
        public int Rating { get; set; }
        public string CustomerReview { get; set; }


    }
}
