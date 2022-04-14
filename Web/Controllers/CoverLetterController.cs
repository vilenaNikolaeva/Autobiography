using Autobiography.Domain;
using Autobiography.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.ViewModels.CoverLetter;

namespace Web.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
        public class CoverLetterController : ControllerBase
        {
        private readonly ICoverLetterService coverLetterService;
        private readonly IMapper mapper;

        public CoverLetterController(ICoverLetterService coverLetterService, IMapper mapper)
        {
            this.coverLetterService = coverLetterService;
            this.mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetUserCoverLetterByIdAsync(string userId)
        {
            var coverLetter = await this.coverLetterService.GetCoverLetterByUserIdAsync(userId);
            var coverLetterModel = this.mapper.Map<CoverLetterViewModel>(coverLetter);
            return Ok(coverLetterModel);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UpdateCoverLetterVIewModel>> UpdateUserCoverLetterByIdAsync(UpdateCoverLetterVIewModel letter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = this.mapper.Map<CoverLetter>(letter);
            await this.coverLetterService.UpdateCoverLetterAsync(user);
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CrateCoverLetterByUserIdAsync(string userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newLetter = await this.coverLetterService.CreateCoverLetterByUserIdAsync(userId);
            if (newLetter == null)
            {
                return BadRequest();
            }
            return Ok(newLetter);
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> DeleteCoverLetterByIdAsync(string userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await this.coverLetterService.DeleteCoverLetterByIdAsync(userId);
            return Ok();
        }
    }
}
