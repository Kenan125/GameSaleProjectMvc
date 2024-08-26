namespace GameSaleProject_Entity.Entities
{
    public class SystemRequirement : BaseEntity
    {





        public string SystemProcessor { get; set; }

        public byte SystemMemory { get; set; }

        public int Storage { get; set; }

        public string Graphics { get; set; }
        public string OS { get; set; }

        public int GameId { get; set; }

        //nav
        public virtual Game Game { get; set; }
    }
}
