using Autobiography.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Autobiography.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> CreateUserAsync(User newUser);
        public Task<User> UpdateUserByIdAsync(string id, User user);
        public Task DeleteUserByIdAsync(string id);
        public Task<IList<Language>> GetLanguagesByUserIdAsync(string id);
        public Task<IList<Skill>> GetSkillByUserIdAsync(string id);
        public Task<IList<Education>> GetEducationByUserIdAsync(string id);
        public Task<IList<Experience>> GetExperienceByUserIdAsync(string id);

    }
}
