using AutoMapper;
using GameSaleProject_DataAccess.Contexts;
using GameSaleProject_Entity.Entities;
using GameSaleProject_Entity.Interfaces;
using GameSaleProject_Entity.UnitOfWorks;
using GameSaleProject_Entity.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GameSaleProject_Service.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly GameSaleProjectDbContext _context;

        public ReviewService(IUnitOfWork unitOfWork, IMapper mapper, GameSaleProjectDbContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<ReviewViewModel>> GetReviewsByGameIdAsync(int gameId)
        {
            var reviews = await _unitOfWork.GetRepository<Review>()
                                           .GetAllAsync(r => r.GameId == gameId);

            foreach (var review in reviews)
            {
                _context.Entry(review).Reference(r => r.User).Load();
            }
            
            return _mapper.Map<List<ReviewViewModel>>(reviews);
        }
        public async Task SubmitReviewAsync(ReviewViewModel reviewModel)
        {
            if (reviewModel.Rating <= 0)
            {
                throw new InvalidOperationException("A star rating is required to submit a review.");
            }

            
            var review = _mapper.Map<Review>(reviewModel);

            
            review.CreatedDate = DateTime.UtcNow;

            
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
