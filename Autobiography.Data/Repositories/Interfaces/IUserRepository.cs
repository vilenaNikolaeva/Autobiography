using Autobiography.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Autobiography.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> FindByIdAsync(string id);
        public Task<User> CreateUserAsync(User newUser);
        public Task<User> UpdateUserAsync(string id, User user);
        public Task DeleteUserAsync(string id);
        public Task<IList<User>> GetUserInfoById(string id);
        public Task<IList<Language>> GetLanguagesByUserIdAsync(string id);
        public Task<IList<Skill>> GetSkillByUserIdAsync(string id);
        public Task<IList<Education>> GetEducationByUserIdAsync(string id);
        public Task<IList<Experience>> GetExperienceByUserIdAsync(string id);

        

    }
}
