using Autobiography.Data.Repositories.Interfaces;
using Autobiography.Domain;
using Autobiography.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autobiography.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<User> CreateUserAsync(User newUser)
        {
            await this.userRepository.CreateUserAsync(newUser);
            return newUser;
        }

        public async Task DeleteUserByIdAsync(string id)
        {
            await this.userRepository.DeleteUserAsync(id);
        }

        public async Task<IList<Education>> GetEducationByUserIdAsync(string id)
        {
            var userEducation = await this.userRepository.GetEducationByUserIdAsync(id);
            return userEducation;
        }

        public async Task<IList<Experience>> GetExperienceByUserIdAsync(string id)
        {
            var userExperience = await this.userRepository.GetExperienceByUserIdAsync(id);
            return userExperience;
        }

        public async Task<IList<Language>> GetLanguagesByUserIdAsync(string id)
        {
            var userLanguage = await this.userRepository.GetLanguagesByUserIdAsync(id);
            return userLanguage;
        }

        public async Task<IList<Skill>> GetSkillByUserIdAsync(string id)
        {
            var userSkill = await this.userRepository.GetSkillByUserIdAsync(id);
            return userSkill;
        }

        public async Task<IList<User>> GetUserInfoById(string id)
        {
            var userInfo = await this.userRepository.GetUserInfoById(id);
            return userInfo;
        }

        public async Task<User> UpdateUserByIdAsync(string id, User user)
        {            
            var updatedUser= await this.userRepository.UpdateUserAsync(id, user);
            return updatedUser;
        }

      
    }
}
