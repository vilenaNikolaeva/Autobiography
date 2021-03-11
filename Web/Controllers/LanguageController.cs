using Autobiography.Domain;
using Autobiography.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.ActionFilters;
using Web.ViewModels;

namespace Web.Controllers
{
    [Authorize]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageService languageService;
        private readonly IMapper mapper;

        public LanguageController(ILanguageService languageService, IMapper mapper)
        {
            this.languageService = languageService;
            this.mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetLanguage")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Get(int id)
        {
            var language = await this.languageService.FindByIdAsync(id);

            if (language == null)
            {
                return NotFound();
            }

            var languageView = this.mapper.Map<SkillViewModel>(language);

            return Ok(languageView);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateLanguageAsync(CreateLanguageViewModel language)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newLanguage = this.mapper.Map<Language>(language);
            await this.languageService.CreateLanguageAsync(newLanguage);
            var createdLanguageModel = this.mapper.Map<LanguageViewModel>(newLanguage);

            return CreatedAtRoute("GetLanguage", new { id = createdLanguageModel.Id }, createdLanguageModel); ;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> UpdateLanguageByIdAsync(int id, UpdateLanguageViewModel skill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedLanguageModel = this.mapper.Map<Language>(skill);
            await this.languageService.UpdateLanguageAsync(id, updatedLanguageModel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> DeleteLanguageByIdAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await this.languageService.DeleteLanguageByIdAsync(id);

            return NoContent();
        }
    }
}
