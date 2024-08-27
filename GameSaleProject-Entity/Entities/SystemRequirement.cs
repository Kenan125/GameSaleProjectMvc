namespace GameSaleProject_Entity.Entities
{
    public class SystemRequirement : BaseEntity
    {


        public string SystemProcessor { get; set; }

        public string SystemMemory { get; set; }

        public string Storage { get; set; }

        public string Graphics { get; set; }
        public string OS { get; set; }

        public int GameId { get; set; }

        //nav
        public virtual Game Game { get; set; }
    }
}
