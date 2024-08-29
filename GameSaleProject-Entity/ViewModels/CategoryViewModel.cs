namespace GameSaleProject_Entity.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<GameViewModel>? Games { get; set; }
    }
}
