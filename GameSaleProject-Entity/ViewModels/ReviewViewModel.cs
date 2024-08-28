using System.ComponentModel.DataAnnotations;

namespace GameSaleProject_Entity.ViewModels
{
    public class ReviewViewModel
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please select a star rating.")]
        public int Rating { get; set; }
        public string CustomerReview { get; set; }


    }
}
