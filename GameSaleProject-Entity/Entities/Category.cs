namespace GameSaleProject_Entity.Entities
{
    public class Category : BaseEntity
    {

        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
