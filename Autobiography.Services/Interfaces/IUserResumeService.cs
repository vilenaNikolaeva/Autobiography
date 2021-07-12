using Autobiography.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autobiography.Services.Interfaces
{
    public interface IUserResumeService
    {
        Task<IList<User>> GetUserInfoById(string id);
        Task<IList<Language>> GetLanguagesByUserIdAsync(string id);
        Task<IList<Skill>> GetSkillByUserIdAsync(string id);
        Task<IList<Education>> GetEducationByUserIdAsync(string id);
        Task<IList<Experience>> GetExperienceByUserIdAsync(string id);
    }
}
