using Autobiography.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class UserImageController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IUserImageService _userImageService;

        public UserImageController( IWebHostEnvironment hostEnvironment, IUserImageService userImageService)
        {
           this._hostEnvironment = hostEnvironment ?? throw new ArgumentNullException(nameof(_hostEnvironment));
            this._userImageService = userImageService;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public  Task<ActionResult> GetUserImageById(string id)
        {
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", id);
            if (imagePath == null)
            {
                 return null;
            }
            var image =  this._userImageService.GetUserImageById(imagePath);
            return null;
        }
        [HttpPost]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SaveImage(IFormFile imageFile, string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await this._userImageService.SaveImage(imageFile, id, _hostEnvironment.ContentRootPath);
            return Ok();
        }
        [NonAction]
        public async Task<ActionResult> DeleteImage(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ImagePath =  Path.Combine(_hostEnvironment.ContentRootPath, "Images", id);
            this._userImageService.DeleteImage(ImagePath);
            return NoContent();
        }

    }
}
