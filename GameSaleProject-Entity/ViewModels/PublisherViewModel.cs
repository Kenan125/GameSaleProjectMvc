using System.ComponentModel.DataAnnotations;

namespace GameSaleProject_Entity.ViewModels
{
    public class PublisherViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Publisher Name is required")]
        public string Name { get; set; }


        public int? UserId { get; set; }
        public UserViewModel User { get; set; }
        public ICollection<GameViewModel> Games { get; set; } = new List<GameViewModel>();
    }
}
