using Autobiography.Data.Repositories.Interfaces;
using Autobiography.Domain;
using Autobiography.Services.Interfaces;
using System.Threading.Tasks;

namespace Autobiography.Services
{
    public class ExperienceService : IExperienceService
    {
        private readonly IExperienceRepository experinceRepository;

        public async Task<Experience> FindByIdAsync(int id)
        {
            return await this.experinceRepository.FindByIdAsync(id);
        }

        public ExperienceService(IExperienceRepository experinceRepository)
        {
            this.experinceRepository = experinceRepository;
        }

        public async Task<Experience> CreateExperinceAsync(Experience newExperience)
        {
           await  this.experinceRepository.CreateExperienceAsync(newExperience);
            return newExperience;
        }

        public async Task DeleteExperienceByIdAsync(int id)
        {
            await this.experinceRepository.DeleteExperienceByIdAsync(id);
        }

        
        public async Task<Experience> UpdateExperienceAsync(int id, Experience experience)
        {
            var updatedExperience = await this.experinceRepository.UpdateExperienceAsync(id, experience);
            return updatedExperience;
        }

    }
}
