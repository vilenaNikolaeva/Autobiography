using Autobiography.Data.Repositories.Interfaces;
using Autobiography.Domain;
using Autobiography.Services.Interfaces;
using System.Threading.Tasks;

namespace Autobiography.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository skillRepository;

        public SkillService(ISkillRepository skillRepository)
        {
            this.skillRepository = skillRepository;
        }

        public async Task<Skill> FindByIdAsync(int id)
        {
            return await this.skillRepository.FindByIdAsync(id);
        }

        public async Task<Skill> CreateSkillAync(Skill newSkill)
        {
            await this.skillRepository.CraeteSkillAsync(newSkill);
            return newSkill;
        }

        public async Task<Skill> UpdateSkillAsync(int id, Skill skill)
        {
            await this.skillRepository.UpdateSkillAsync(id, skill);
            return skill;
        }
        public async Task DeleteSkillByIdAsync(int id)
        {
            await this.skillRepository.DeleteSkillByIdAsync(id);
        }

      
    }
}
