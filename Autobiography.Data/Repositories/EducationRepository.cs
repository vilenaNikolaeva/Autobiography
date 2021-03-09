using Autobiography.Data.Repositories.Interfaces;
using Autobiography.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Autobiography.Data.Repositories
{
    public class EducationRepository : BaseRepositoryContext, IEducationRepository
    {
        public EducationRepository(AutobiographyDbContext context)
            : base(context)
        {
        }
        public async Task<Education> FindByIdAsync(int id)
        {
            return await this.context.Educations.FindAsync(id);
        }

        public async Task<Education> CreateEducationAsync(Education newEducation)
        {
            await this.context.Educations.AddAsync(newEducation);
            await this.context.SaveChangesAsync();
            return newEducation;
        }

        public async Task DeleteEducationByIdAsync(int id)
        {
            var education = await this.FindByIdAsync(id);
            this.context.Educations.Remove(education);
            await this.context.SaveChangesAsync();
        }

        public async Task<Education> UpdateEducationAsync(int id, Education education)
        {
            var educationForUpdate = await this.FindByIdAsync(id);

            educationForUpdate.StartDate = education.StartDate;
            educationForUpdate.EndDate = education.EndDate;
            educationForUpdate.University = education.University;
            educationForUpdate.Title = education.Title;
            educationForUpdate.Description = education.Description;

            this.context.Educations.Update(educationForUpdate);
            await this.context.SaveChangesAsync();
            return education;
        }
    }
}
