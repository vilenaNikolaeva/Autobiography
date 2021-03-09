﻿using Autobiography.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autobiography.Services.Interfaces
{
    public interface IUserService
    {
        public Task<User> CreateUserAsync(User newUser);

         Task<User> UpdateUserByIdAsync(string id, User user);
         Task DeleteUserByIdAsync(string id);
         Task<IList<Language>> GetLanguagesByUserIdAsync(string id);
         Task<IList<Skill>> GetSkillByUserIdAsync(string id);
         Task<IList<Education>> GetEducationByUserIdAsync(string id);
         Task<IList<Experience>> GetExperienceByUserIdAsync(string id);
    }
}
