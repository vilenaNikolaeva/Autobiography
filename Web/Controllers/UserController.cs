using Autobiography.Common;
using Autobiography.Domain;
using Autobiography.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.Controllers
{
    [Authorize]
    //[ServiceFilter(typeof(ValidationFilterAttribute))]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IUserImageService _userImageService;

        public UserController(IUserService userService, IMapper mapper, IWebHostEnvironment hostEnvironment, IUserImageService userImageService)
        {
            this._userService = userService;
            this._mapper = mapper;
            this._hostEnvironment = hostEnvironment;
            this._userImageService = userImageService;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetUserInfoById(string id)
        {
            var userInfo =  await this._userService.GetUserInfoById(id);
            var userInfoModel = this._mapper.Map<IList<CreateUserViewModel>>(userInfo);
          
            return Ok(userInfoModel);
        }

        [HttpGet]
        [Route("{id}/languages")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetLanguagesByUserIdAsync(string id)
        {
            var languages = await this._userService.GetLanguagesByUserIdAsync(id);
            var languageModel = this._mapper.Map<IList<LanguageViewModel>>(languages);

            return Ok(languageModel);
        }

        [HttpGet]
        [Route("{id}/skills")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetSkillsByUserIdAsync(string id)
        {
            var skills = await this._userService.GetSkillByUserIdAsync(id);
            var skillModel = this._mapper.Map<IList<SkillViewModel>>(skills);
            return Ok(skillModel);
        }

        [HttpGet]
        [Route("{id}/experiences")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetExperiencesByUserIdAsync(string id)
        {
            var experiences = await this._userService.GetExperienceByUserIdAsync(id);
            var experienceModel = this._mapper.Map<IList<ExperienceViewModel>>(experiences);
            return Ok(experienceModel);
        }

        [HttpGet]
        [Route("{id}/educations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetEducationByUserIdAsync(string id)
        {
            var educations = await this._userService.GetEducationByUserIdAsync(id);
            var educationModel = this._mapper.Map<IList<EducationViewModel>>(educations);
            return Ok(educationModel);
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteUserByIdAsync(string id)
        {
            this._userImageService.DeleteImage(id,id);
            await this._userService.DeleteUserByIdAsync(id);
            return Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UpdateUserViewModel>> UpdateUserByIdAsync(string id, [FromForm] UpdateUserViewModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (userModel.ImageFile != null)
            {
                var imageName = await this._userImageService.SaveImage(userModel.ImageFile, id, _hostEnvironment.ContentRootPath);
                var imageSrc = $"{Request.Scheme}://{Request.Host}{Request.PathBase}/{Constants.IMAGES_FOLDER}/{imageName}";
                userModel.ImageSrc = imageSrc;
                userModel.ImageFile = null;
            }
            else if(userModel.ImageSrc== "null")
            {
                var folder = Path.Combine(_hostEnvironment.ContentRootPath, Constants.IMAGES_FOLDER);
                this._userImageService.DeleteImage(folder,id);
                userModel.ImageSrc = null;
                userModel.ImageFile = null;
            }

            var user = this._mapper.Map<User>(userModel);
            await this._userService.UpdateUserByIdAsync(id, user);
            return Ok(userModel);
        }
    }
} 
