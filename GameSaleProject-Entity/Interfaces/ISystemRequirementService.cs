using GameSaleProject_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaleProject_Entity.Interfaces
{
    public interface ISystemRequirementService
    {
        Task<SystemRequirementViewModel?> GetSystemRequirementsByGameIdAsync(int gameId);
    }
}
