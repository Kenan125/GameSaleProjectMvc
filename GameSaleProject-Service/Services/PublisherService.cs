using AutoMapper;
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
    public class PublisherService : IPublisherService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PublisherService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PublisherViewModel>> GetAllPublishersAsync()
        {
            var publisherRepository = _unitOfWork.GetRepository<Publisher>();
            var publishers = await publisherRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PublisherViewModel>>(publishers);
        }

        public async Task<PublisherViewModel> GetPublisherByIdAsync(int publisherId)
        {
            var publisher = await _unitOfWork.GetRepository<Publisher>().GetByIdAsync(publisherId);
            if (publisher == null)
            {
                return null;
            }

            return new PublisherViewModel
            {
                Id = publisher.Id,
                Name = publisher.Name
            };
        }
        public async Task<bool> CreatePublisherAsync(PublisherViewModel model, int userId)
        {
            try
            {
                var publisher = new Publisher
                {
                    Name = model.Name,
                    UserId = userId,
                };

                await _unitOfWork.GetRepository<Publisher>().Add(publisher);
                await _unitOfWork.CommitAsync();

                return true;
            }
            catch (Exception)
            {
                // Handle exceptions, log them if necessary
                return false;
            }
        }
        public async Task<PublisherViewModel> GetPublisherByUserIdAsync(int userId)
        {
            var publisher = await _unitOfWork.GetRepository<Publisher>().GetAll(
                filter: p => p.UserId == userId,
                includes: p=>p.Games

            );

            if (publisher == null)
            {
                return null;
            }

            return _mapper.Map<PublisherViewModel>(publisher.FirstOrDefault());
        }
    }
}
