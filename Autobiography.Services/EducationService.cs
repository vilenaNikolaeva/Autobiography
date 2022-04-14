using Autobiography.Data.Repositories.Interfaces;
using Autobiography.Domain;
using Autobiography.Services.Interfaces;
using System.Threading.Tasks;

namespace Autobiography.Services
{
    public class EducationService : IEducationService
    {
        private readonly IEducationRepository educationRepository;


        public EducationService(IEducationRepository educationRepository)
        {
            this.educationRepository = educationRepository;
        }
        public async Task<Education> FindByIdAsync(int id)
        {
            return await this.educationRepository.FindByIdAsync(id);
        }

        public async Task<Education> CreateEducationAsync(Education newEducation)
        {
            await this.educationRepository.CreateEducationAsync(newEducation);
            return newEducation;
        }

        public async Task DeleteEducationByIdAsync(int id)
        {
            await this.educationRepository.DeleteEducationByIdAsync(id);
        }

        public async Task<Education> UpdateEducationAsync(int id, Education education)
        {
            var updatedExperience = await this.educationRepository.UpdateEducationAsync(id, education);
            return updatedExperience;
        }
    }
}
