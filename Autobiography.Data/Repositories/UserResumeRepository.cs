using Autobiography.Data.Repositories.Interfaces;
using Autobiography.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autobiography.Data.Repositories
{
    public class UserResumeRepository : BaseRepositoryContext, IUserResumeRepository
    {
        public UserResumeRepository(AutobiographyDbContext context)
            :base(context)
        {
        }

        public async Task<User> FindByIdAsync(string id)
        {
            return await this.context.Users.FindAsync(id);
        }
        public async Task<IList<Education>> GetEducationByUserIdAsync(string id)
        {
            var educations = await this.context.Educations.Where(e => e.UserId == id).ToListAsync();
            return educations;
        }
        public async Task<IList<Experience>> GetExperienceByUserIdAsync(string id)
        {
            var experiences = await this.context.Experiences.Where(e => e.UserId == id).ToListAsync();
            return experiences;
        }
        public async Task<IList<Language>> GetLanguagesByUserIdAsync(string id)
        {
            var languages = await this.context.Languages.Where(l => l.UserId == id).ToListAsync();
            return languages;
        }
        public async Task<IList<Skill>> GetSkillByUserIdAsync(string id)
        {
            var skills = await this.context.Skills.Where(s => s.UserId == id).ToListAsync();
            return skills;
        }
        public async Task<IList<User>> GetUserInfoById(string id)
        {
            var currentInfo = await this.context.Users.Where(s => s.Id == id).ToListAsync();
            return currentInfo;

        }
    }
}
