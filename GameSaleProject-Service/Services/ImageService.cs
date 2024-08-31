using GameSaleProject_Entity.Interfaces;
using GameSaleProject_Entity.UnitOfWorks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace GameSaleProject_Service.Services
{
    public class ImageService : IImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _environment;
        public ImageService(IUnitOfWork unitOfWork, IWebHostEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _environment = environment;
        }
        public async Task<string> UploadImageAsync(IFormFile imageFile, string imageType)
        {
            var fileName = $"{Path.GetFileNameWithoutExtension(imageFile.FileName)}_{DateTime.Now.Ticks}{Path.GetExtension(imageFile.FileName)}";
            var filePath = Path.Combine(_environment.WebRootPath, "images", fileName);

            if (!Directory.Exists(Path.Combine(_environment.WebRootPath, "images")))
            {
                Directory.CreateDirectory(Path.Combine(_environment.WebRootPath, "images"));
            }

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            return $"/images/{fileName}";
        }

        
    }
}
