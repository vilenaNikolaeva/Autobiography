using Autobiography.Domain;
using System.Threading.Tasks;

namespace Autobiography.Data.Repositories.Interfaces
{
    public interface ISkillRepository
    {
        public Task<Skill> FindByIdAsync(int id);
        public Task<Skill> CraeteSkillAsync(Skill newSkill);
        public Task<Skill> UpdateSkillAsync(int id, Skill user);
        public Task DeleteSkillByIdAsync(int id);
    }
}