using Autobiography.Common;
using Autobiography.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Autobiography.Services
{
    public class UserImageService : IUserImageService
    {
        public async Task<string> SaveImage(IFormFile file,string newFileName , string rootPath)
        {
            if (file != null)
            {
                var fileName = newFileName + "_" + Guid.NewGuid() + ".jpg";
                var folder = Path.Combine(rootPath, Constants.IMAGES_FOLDER);

                var imagePath = Path.Combine(rootPath, Constants.IMAGES_FOLDER, fileName);
                DeleteImage(folder, newFileName);

                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                return fileName;
            }

            return null;           
        }

        public void DeleteImage(string folder, string fileName)
        {
           var contentFolder = Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories);

            foreach (var file in contentFolder)
            {
                if (file.Contains(fileName))
                {
                     File.Delete(file);
                    break;
                }
            }
            
            //if (imagePath.Contains(fileName))
            //{
            //    File.Delete(imagePath);
            //}
            //if (File.Exists(imagePath.Split('_')[1]))
            //{
            //    File.Delete(imagePath);
            //}
        }
    }
}
