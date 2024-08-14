using GameSaleProject_Entity.Entities;
using GameSaleProject_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaleProject_Entity.Interfaces
{
    public interface IPublisherService 
    {
        Task<IEnumerable<PublisherViewModel>> GetAllPublishersAsync();
    }
}
