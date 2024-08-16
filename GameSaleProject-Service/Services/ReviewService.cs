using GameSaleProject_Entity.Entities;
using GameSaleProject_Entity.Interfaces;
using GameSaleProject_Entity.UnitOfWorks;
using GameSaleProject_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
