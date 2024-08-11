namespace GameSaleProject_Entity.Entities
{
    public class Publisher : BaseEntity
	{
        

        public string Name { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}
