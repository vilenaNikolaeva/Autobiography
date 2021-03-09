using Autobiography.Domain;
using Autobiography.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.Controllers
{
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }                 

        [HttpGet]
        [Route("{id}/languages")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetLanguagesByUserIdAsync(string id)
        {
        //    if (this.User.FindFirst("UserId").Value == id) { }

            //TODO check  if the user exist.
            var languages = await this.userService.GetLanguagesByUserIdAsync(id);
            var languageModel = this.mapper.Map<IList<LanguageViewModel>>(languages);

            return Ok(languageModel);
        }

        [HttpGet]
        [Route("{id}/skills")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetSkillsByUserIdAsync(string id)
        {
            //TODO check  if the user exist.
            var skills = await this.userService.GetSkillByUserIdAsync(id);
            var skillModel = this.mapper.Map<IList<CreateSkillViewModel>>(skills);
            return Ok(skillModel);
        }

        [HttpGet]
        [Route("{id}/experiences")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetExperiencesByUserIdAsync(string id)
        {
            //TODO check  if the user exist.
            var experiences = await this.userService.GetExperienceByUserIdAsync(id);
            var experienceModel = this.mapper.Map<IList<CreateExperienceViewModel>>(experiences);
            return Ok(experienceModel);
        }

        [HttpGet]
        [Route("{id}/educations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetEducationByUserIdAsync(string id)
        {
            //TODO check  if the user exist.
            var educations = await this.userService.GetEducationByUserIdAsync(id);
            var educationModel = this.mapper.Map<IList<CreateEducationViewModel>>(educations);
            return Ok(educationModel);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> DeleteUserByIdAsync(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await this.userService.DeleteUserByIdAsync(id);
            return Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> UpdateUserByIdAsync(string id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await this.userService.UpdateUserByIdAsync(id, user);
            return Ok();
        }
    }
}
