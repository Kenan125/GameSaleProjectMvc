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
    public class SystemRequirementService : ISystemRequirementService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SystemRequirementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SystemRequirementViewModel?> GetSystemRequirementsByGameIdAsync(int gameId)
        {
            var systemRequirements = await _unitOfWork.GetRepository<SystemRequirement>()
                                                      .GetAllAsync(sr => sr.GameId == gameId);

            var requirement = systemRequirements.FirstOrDefault();
            if (requirement == null)
            {
                return null;
            }

            return new SystemRequirementViewModel
            {
                Id = requirement.Id,
                OS = requirement.OS,
                SystemProcessor = requirement.SystemProcessor,
                SystemMemory = requirement.SystemMemory,
                Storage = requirement.Storage,
                Graphics = requirement.Graphics,
                
            };
        }
    }
}
