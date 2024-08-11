namespace GameSaleProject_Entity.Entities
{
    public class Category : BaseEntity
    {
        
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<Game> Games { get; set; }
    }
}
