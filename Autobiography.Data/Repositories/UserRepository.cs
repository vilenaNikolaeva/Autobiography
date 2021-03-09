using Autobiography.Data.Repositories.Interfaces;
using Autobiography.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autobiography.Data.Repositories
{
    public class UserRepository : BaseRepositoryContext, IUserRepository
    {
        public UserRepository(AutobiographyDbContext context)
            : base(context)
        {
        }

        public async Task<User> CreateUserAsync(User newUser)
        {
            await this.context.Users.AddAsync(newUser);
            await this.context.SaveChangesAsync();
            return newUser;
        }

        public async Task DeleteUserByIdAsync(string id)
        {
            var user =await this.context.Users.SingleOrDefaultAsync(u => u.Id == id);
            this.context.Users.Remove(user);
            await this.context.SaveChangesAsync();
        }

        public async  Task<IList<Education>> GetEducationByUserIdAsync(string id)
        {
            var user = await this.context.Users.Include(u => u.Educations).FirstOrDefaultAsync(l => l.Id == id);
            var educations = user.Educations.ToList();
            return educations;
        }

        public async Task<IList<Experience>> GetExperienceByUserIdAsync(string id)
        {
            var user = await this.context.Users.Include(u => u.Experiences).FirstOrDefaultAsync(l => l.Id == id);
            var experiences = user.Experiences.ToList();
            return experiences;
        }

        public async Task<IList<Language>> GetLanguagesByUserIdAsync(string id)
        {
            var user = await this.context.Users.Include(u => u.Languages).FirstOrDefaultAsync(l => l.Id == id);
            var language = user.Languages.ToList();
            return language;
        }
        public async Task<IList<Skill>> GetSkillByUserIdAsync(string id)
        {
            var skill = await this.context.Users.Include(u => u.Skills).FirstOrDefaultAsync(skill => skill.Id == id);
            var skills = skill.Skills.ToList();
            return skills;
        }

        public async Task<User> UpdateUserByIdAsync(string id,User user)
        {
            user.Id = id;
            this.context.Users.Update(user);
            await this.context.SaveChangesAsync();
            return user;
        }
    }
}
