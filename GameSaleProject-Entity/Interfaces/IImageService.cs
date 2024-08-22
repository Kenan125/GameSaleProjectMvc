using GameSaleProject_Entity.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaleProject_Entity.Interfaces
{
    public interface IImageService 
    {
        Task<string> UploadImageAsync(IFormFile imageFile, string imageType);
        Task DeleteImageAsync(string imageUrl);
    }
}
