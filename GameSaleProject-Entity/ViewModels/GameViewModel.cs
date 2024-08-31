namespace GameSaleProject_Entity.ViewModels
{
    public class GameViewModel
    {
        public int Id { get; set; }
        public string GameName { get; set; }


        public string? Description { get; set; }


        public int Discount { get; set; }


        public decimal Price { get; set; }

        public string? Developer { get; set; }


        public int PublisherId { get; set; }


        public int CategoryId { get; set; }

        public string? Platform { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsInLibrary { get; set; }
        public bool IsDeleted { get; set; }
        public double AverageRating { get; set; }

        //new prop
        public List<ImageViewModel>? Images { get; set; } = new List<ImageViewModel>();
        public ICollection<ReviewViewModel>? Reviews { get; set; } = new List<ReviewViewModel>();
        public ReviewViewModel? NewReview { get; set; }
        public SystemRequirementViewModel? SystemRequirements { get; set; }
        public PublisherViewModel? Publisher { get; set; }
        public CategoryViewModel Category { get; set; }
        public SystemRequirementViewModel SystemRequirement { get; set; }

    }
}
