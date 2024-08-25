namespace GameSaleProject_Entity.ViewModels
{
    public class GameCategoryPublisherViewModel
    {
        public IEnumerable<GameViewModel> Games { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; }
        public IEnumerable<PublisherViewModel> Publishers { get; set; } // Add this line
    }
}
