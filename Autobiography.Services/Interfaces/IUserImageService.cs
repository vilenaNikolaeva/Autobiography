using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Autobiography.Services.Interfaces
{
    public interface IUserImageService
    {
        //Task GetUserImageById(string fileId);
        Task<string> SaveImage(IFormFile file, string newFileName, string rootPath);
        void  DeleteImage(string imagePath, string imageFile);
    }
}
