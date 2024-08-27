﻿namespace GameSaleProject_Entity.ViewModels
{
    public class SystemRequirementViewModel
    {
        public int Id { get; set; }
        public string OS { get; set; }
        
        public string SystemProcessor { get; set; }
        public string SystemMemory { get; set; }
        public string Storage { get; set; }
        public string Graphics { get; set; }
        public int GameId { get; set; }

        public virtual GameViewModel Game { get; set; }
    }
}
