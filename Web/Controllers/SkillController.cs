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
    public class SkillController : ControllerBase
    {
        private readonly ISkillService skillService;
        private readonly IMapper mapper;

        public SkillController(ISkillService skillService, IMapper mapper)
        {
            this.skillService = skillService;
            this.mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetSkill")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Get(int id)
        {
            var skill = await this.skillService.FindByIdAsync(id);

            if (skill == null)
            {
                return NotFound();
            }

            var skillView = this.mapper.Map<SkillViewModel>(skill);

            return Ok(skillView);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateSkillAsync(CreateSkillViewModel skill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newSkill = this.mapper.Map<Skill>(skill);
            await this.skillService.CreateSkillAync(newSkill);
            var createdSkillModel = this.mapper.Map<SkillViewModel>(newSkill);

            return CreatedAtRoute("GetSkill", new { id = createdSkillModel.Id }, createdSkillModel); ;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> UpdateSkillByIdAsync(int id, UpdateSkillViewModel skill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedSkillModel = this.mapper.Map<Skill>(skill);
            await this.skillService.UpdateSkillAsync(id, updatedSkillModel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> DeleteSkillByIdAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await this.skillService.DeleteSkillByIdAsync(id);

            return NoContent();
        }

    }
}
