using GameSaleProject_Entity.Entities;
using GameSaleProject_Entity.Interfaces;
using GameSaleProject_Entity.UnitOfWorks;
using GameSaleProject_Entity.ViewModels;

namespace GameSaleProject_Service.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReviewService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ReviewViewModel>> GetReviewsByGameIdAsync(int gameId)
        {
            var reviews = await _unitOfWork.GetRepository<Review>()
                                       .GetAllAsync(r => r.GameId == gameId);

            return reviews.Select(r => new ReviewViewModel
            {
                Id = r.Id,
                GameId = r.GameId,
                CustomerId = r.CustomerId,
                Rating = r.Rating,
                CustomerReview = r.CustomerReview
            }).ToList();
        }
        public async Task SubmitReviewAsync(ReviewViewModel reviewModel)
        {

            if (reviewModel.Rating <= 0)
            {
                throw new InvalidOperationException("A star rating is required to submit a review.");
            }

            var review = new Review
            {
                GameId = reviewModel.GameId,
                CustomerId = reviewModel.CustomerId,
                Rating = reviewModel.Rating,
                CustomerReview = string.IsNullOrEmpty(reviewModel.CustomerReview) ? null : reviewModel.CustomerReview,
                CreatedDate = DateTime.UtcNow
            };

            await _unitOfWork.GetRepository<Review>().Add(review);
            await _unitOfWork.CommitAsync();
        }

        public async Task<double> GetAverageRatingByGameIdAsync(int gameId)
        {
            var reviews = await _unitOfWork.GetRepository<Review>()
                                           .GetAllAsync(r => r.GameId == gameId);

            if (reviews == null || !reviews.Any())
            {
                return 0;
            }

            return reviews.Average(r => r.Rating);
        }
    }
}
