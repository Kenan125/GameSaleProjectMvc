using AutoMapper;
using GameSaleProject_Entity.Entities;
using GameSaleProject_Entity.Interfaces;
using GameSaleProject_Entity.UnitOfWorks;
using GameSaleProject_Entity.ViewModels;

namespace GameSaleProject_Service.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReviewService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ReviewViewModel>> GetReviewsByGameIdAsync(int gameId)
        {
            var reviews = await _unitOfWork.GetRepository<Review>()
                                           .GetAllAsync(r => r.GameId == gameId);

            // Use AutoMapper to map the list of Review entities to a list of ReviewViewModel
            return _mapper.Map<List<ReviewViewModel>>(reviews);
        }
        public async Task SubmitReviewAsync(ReviewViewModel reviewModel)
        {
            if (reviewModel.Rating <= 0)
            {
                throw new InvalidOperationException("A star rating is required to submit a review.");
            }

            // Use AutoMapper to map ReviewViewModel to Review entity
            var review = _mapper.Map<Review>(reviewModel);

            // Set any additional properties not handled by AutoMapper
            review.CreatedDate = DateTime.UtcNow;

            // Add and commit the review to the database
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
