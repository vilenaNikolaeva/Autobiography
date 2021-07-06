using Autobiography.Data.Repositories.Interfaces;
using Autobiography.Domain;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
        public async Task<User> FindByIdAsync(string id)
        {
            return await this.context.Users.FindAsync(id);
        }


        public async Task<User> CreateUserAsync(User newUser)
        {
            await this.context.Users.AddAsync(newUser);
            await this.context.SaveChangesAsync();
            return newUser;
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

        public async Task<User> UpdateUserAsync(string id, User user)
        {
            var userForUpdate = await this.FindByIdAsync(id);

            userForUpdate.ImageSrc = user.ImageSrc ?? userForUpdate.ImageSrc;
            userForUpdate.UserName = user.UserName ?? userForUpdate.UserName;
            userForUpdate.Email = user.Email ?? userForUpdate.Email;
            userForUpdate.Link = user.Link ?? userForUpdate.Link;
            userForUpdate.Address = user.Address ?? userForUpdate.Address;
            userForUpdate.Description = user.Description ?? userForUpdate.Description;

            this.context.Users.Update(userForUpdate);
            await this.context.SaveChangesAsync();
            return userForUpdate;
        }
        public async Task DeleteUserAsync(string id)
        {
            var user = await this.FindByIdAsync(id);
            this.context.Users.Remove(user);
            await this.context.SaveChangesAsync();
        }

        public async Task<IList<User>> GetUserInfoById(string id)
        {
            var currentInfo = await this.context.Users.Where(s => s.Id == id).ToListAsync();
            return  currentInfo;
            
        }
    }
}
