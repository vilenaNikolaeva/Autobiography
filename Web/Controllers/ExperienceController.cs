using Autobiography.Domain;
using Autobiography.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        private readonly IExperienceService experinceService;
        private readonly IMapper mapper;

        public ExperienceController(IExperienceService experinceService, IMapper mapper)
        {
            this.experinceService = experinceService;
            this.mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetExperience")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Get(int id)
        {
            var experience = await this.experinceService.FindByIdAsync(id);

            if (experience == null)
            {
                return NotFound();
            }

            var experienceView = this.mapper.Map<ExperienceViewModel>(experience);

            return Ok(experienceView);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateExperienceAsync(CreateExperienceViewModel experince)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newExperience = this.mapper.Map<Experience>(experince);
            await this.experinceService.CreateExperinceAsync(newExperience);
            var createdExperienceModel = this.mapper.Map<ExperienceViewModel>(newExperience);

            return CreatedAtRoute("GetExperience", new { id = createdExperienceModel.Id }, createdExperienceModel); ;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> UpdateExperienceByIdAsync(int id, UpdateExperienceViewModel experience)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedExperienceModel = this.mapper.Map<Experience>(experience);
            await this.experinceService.UpdateExperienceAsync(id, updatedExperienceModel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> DeleteExperienceByIdAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await this.experinceService.DeleteExperienceByIdAsync(id);
            return Ok();
        }
    }
}
