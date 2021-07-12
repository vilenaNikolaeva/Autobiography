using Autobiography.Data.Repositories.Interfaces;
using Autobiography.Domain;
using Autobiography.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autobiography.Services
{
    public class UserResumeService : IUserResumeService
    {
        private readonly IUserResumeRepository userResumeRepository;

        public UserResumeService(IUserResumeRepository userResumeRepository)
        {
            this.userResumeRepository = userResumeRepository;
        }
        public async Task<IList<Education>> GetEducationByUserIdAsync(string id)
        {
            var userEducation = await this.userResumeRepository.GetEducationByUserIdAsync(id);
            return userEducation;
        }
        public async Task<IList<Experience>> GetExperienceByUserIdAsync(string id)
        {
            var userExperience = await this.userResumeRepository.GetExperienceByUserIdAsync(id);
            return userExperience;
        }
        public async Task<IList<Language>> GetLanguagesByUserIdAsync(string id)
        {
            var userLanguage = await this.userResumeRepository.GetLanguagesByUserIdAsync(id);
            return userLanguage;
        }
        public async Task<IList<Skill>> GetSkillByUserIdAsync(string id)
        {
            var userSkill = await this.userResumeRepository.GetSkillByUserIdAsync(id);
            return userSkill;
        }
        public async Task<IList<User>> GetUserInfoById(string id)
        {
            var userInfo = await this.userResumeRepository.GetUserInfoById(id);
            return userInfo;
        }
    }
}
