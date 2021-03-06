using Autobiography.Domain;
using System.Threading.Tasks;

namespace Autobiography.Services.Interfaces
{
    public interface ISkillService
    {
        Task<Skill> FindByIdAsync(int id);
        Task<Skill> CreateSkillAync(Skill newSkill);
        Task<Skill> UpdateSkillAsync(int id, Skill skill);
        Task DeleteSkillByIdAsync(int id);
    }
}
