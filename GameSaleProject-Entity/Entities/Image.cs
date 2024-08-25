namespace GameSaleProject_Entity.Entities
{
    public class Image : BaseEntity
    {

        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string? ImageType { get; set; }
        public int GameId { get; set; }

        public virtual Game Game { get; set; }

    }
}
