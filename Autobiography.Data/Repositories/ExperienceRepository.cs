using Autobiography.Data.Repositories.Interfaces;
using Autobiography.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Autobiography.Data.Repositories
{
    public class ExperienceRepository : BaseRepositoryContext, IExperienceRepository
    {
        public ExperienceRepository(AutobiographyDbContext context) : base(context)
        {
        }

        public async  Task<Experience> FindByIdAsync(int id)
        {
            return  await this.context.Experiences.FindAsync(id);
        }

        public async Task<Experience> CreateExperienceAsync(Experience newExperience)
        {
            await this.context.Experiences.AddAsync(newExperience);
            await this.context.SaveChangesAsync();

            return newExperience;
        }

        public async Task DeleteExperienceByIdAsync(int id)
        {

            var experience = await this.FindByIdAsync(id);
            this.context.Experiences.Remove(experience);
            await this.context.SaveChangesAsync();
        }

        public async Task<Experience> UpdateExperienceAsync(int id, Experience experience)
        {
            var experienceForUpdate = await this.FindByIdAsync(id);
           
            experienceForUpdate.CompanyName = experience.CompanyName;
            experienceForUpdate.Description = experience.Description;
            experienceForUpdate.StillWork = experience.StillWork;
            experienceForUpdate.StartDate =experience.StartDate;
            experienceForUpdate.EndDate = experience.EndDate;

            this.context.Experiences.Update(experienceForUpdate);
            await this.context.SaveChangesAsync();
            return experienceForUpdate;
        }
    }
}
