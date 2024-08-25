using GameSaleProject_Entity.Entities;
using GameSaleProject_Entity.Interfaces;
using GameSaleProject_Entity.UnitOfWorks;
using GameSaleProject_Entity.ViewModels;

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
        public async Task SaveSystemRequirementsAsync(SystemRequirementViewModel model)
        {
            var repository = _unitOfWork.GetRepository<SystemRequirement>();

            var existingRequirement = await repository.Get(r => r.GameId == model.GameId);
            if (existingRequirement != null)
            {

                existingRequirement.OS = model.OS;
                existingRequirement.SystemProcessor = model.SystemProcessor;
                existingRequirement.SystemMemory = model.SystemMemory;
                existingRequirement.Storage = model.Storage;
                existingRequirement.Graphics = model.Graphics;

                repository.Update(existingRequirement);
            }
            else
            {

                var systemRequirement = new SystemRequirement
                {
                    GameId = model.GameId,
                    OS = model.OS,
                    SystemProcessor = model.SystemProcessor,
                    SystemMemory = model.SystemMemory,
                    Storage = model.Storage,
                    Graphics = model.Graphics,
                };

                await repository.Add(systemRequirement);
            }

            await _unitOfWork.CommitAsync();
        }
    }
}
