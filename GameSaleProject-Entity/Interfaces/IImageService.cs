using Microsoft.AspNetCore.Http;

namespace GameSaleProject_Entity.Interfaces
{
    public interface IImageService
    {
        Task<string> UploadImageAsync(IFormFile imageFile, string imageType);
        
    }
}
