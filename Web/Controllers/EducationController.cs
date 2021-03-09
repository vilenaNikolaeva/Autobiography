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
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IEducationService educationService;
        private readonly IMapper mapper;

        public EducationController(IEducationService educationService, IMapper mapper)
        {
            this.educationService = educationService;
            this.mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetEducation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Get(int id)
        {
            var education = await this.educationService.FindByIdAsync(id);

            if (education == null)
            {
                return NotFound();
            }

            var educationView = this.mapper.Map<EducationViewModel>(education);

            return Ok(educationView);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateEducationAsync(CreateEducationViewModel education)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newEducation = this.mapper.Map<Education>(education);
            await this.educationService.CreateEducationAsync(newEducation);
            var createdEducationModel = this.mapper.Map<EducationViewModel>(newEducation);

            return CreatedAtRoute("GetEducation", new { id = createdEducationModel.Id }, createdEducationModel); ;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> UpdateEducationByIdAsync(int id, UpdateEducationViewModel education)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedEducationModel = this.mapper.Map<Education>(education);
            await this.educationService.UpdateEducationAsync(id, updatedEducationModel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> DeleteEducationByIdAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await this.educationService.DeleteEducationByIdAsync(id);
            return Ok();
        }
    }
}
