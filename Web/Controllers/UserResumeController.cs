using Autobiography.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class UserResumeController : ControllerBase
    {
        private readonly IUserResumeService _userResumeService;
        private readonly IMapper _mapper;

        public UserResumeController(IUserResumeService userResumeService, IMapper mapper)
        {
            _userResumeService = userResumeService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetUserInfoById(string id)
        {
            var userInfo = await this._userResumeService.GetUserInfoById(id);
            var userInfoModel = this._mapper.Map<IList<CreateUserViewModel>>(userInfo);

            if (userInfoModel[0].IsItPublic)
            {
                return Ok(userInfoModel);
            }

            return NotFound();         
        }
        [HttpGet]
        [Route("{id}/languages")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetLanguagesByUserIdAsync(string id)
        {
            var languages = await this._userResumeService.GetLanguagesByUserIdAsync(id);
            var languageModel = this._mapper.Map<IList<LanguageViewModel>>(languages);

            return Ok(languageModel);
        }
        [HttpGet]
        [Route("{id}/skills")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetSkillsByUserIdAsync(string id)
        {
            var skills = await this._userResumeService.GetSkillByUserIdAsync(id);
            var skillModel = this._mapper.Map<IList<SkillViewModel>>(skills);
            return Ok(skillModel);
        }
        [HttpGet]
        [Route("{id}/experiences")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetExperiencesByUserIdAsync(string id)
        {
            var experiences = await this._userResumeService.GetExperienceByUserIdAsync(id);
            var experienceModel = this._mapper.Map<IList<ExperienceViewModel>>(experiences);
            return Ok(experienceModel);
        }
        [HttpGet]
        [Route("{id}/educations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetEducationByUserIdAsync(string id)
        {
            var educations = await this._userResumeService.GetEducationByUserIdAsync(id);
            var educationModel = this._mapper.Map<IList<EducationViewModel>>(educations);
            return Ok(educationModel);
        }
    }
}
