using GameSaleProject_Entity.ViewModels;

namespace GameSaleProject_Entity.Interfaces
{
    public interface IPublisherService
    {
        Task<IEnumerable<PublisherViewModel>> GetAllPublishersAsync();
        Task<PublisherViewModel> GetPublisherByIdAsync(int publisherId);
        Task<bool> CreatePublisherAsync(PublisherViewModel model, int userId);
        Task<PublisherViewModel> GetPublisherByUserIdAsync(int userId);
    }
}
