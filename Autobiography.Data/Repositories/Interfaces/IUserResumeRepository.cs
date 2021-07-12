using Autobiography.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autobiography.Data.Repositories.Interfaces
{
    public interface IUserResumeRepository
    {
        public Task<User> FindByIdAsync(string id);
        public Task<IList<User>> GetUserInfoById(string id);
        public Task<IList<Language>> GetLanguagesByUserIdAsync(string id);
        public Task<IList<Skill>> GetSkillByUserIdAsync(string id);
        public Task<IList<Education>> GetEducationByUserIdAsync(string id);
        public Task<IList<Experience>> GetExperienceByUserIdAsync(string id);

    }
}
