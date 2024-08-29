using System.ComponentModel.DataAnnotations;

namespace GameSaleProject_Entity.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public virtual ICollection<GameViewModel>? Games { get; set; }
    }
}
