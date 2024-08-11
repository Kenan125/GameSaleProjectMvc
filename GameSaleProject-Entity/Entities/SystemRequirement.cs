using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameSaleProject_Entity.Entities
{
    public class SystemRequirement : BaseEntity
	{
        
        [Required]
        public string OS { get; set; }
        [Required]
        public bool IsMinimum { get; set; }
        [Required]
        public string SystemProcessor { get; set; }
        [Required]
        public byte SystemMemory { get; set; }
        [Required]
        public int Storage { get; set; }
        [Required]
        public string Graphics { get; set; }
        [Required]
        public int GameId { get; set; }

        
        public virtual Game Game { get; set; }
    }
}
