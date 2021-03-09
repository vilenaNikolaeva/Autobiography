using Autobiography.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Autobiography.Data.Repositories.Interfaces
{
    public interface IExperienceRepository
    {
        public Task<Experience> FindByIdAsync(int id);
        public Task<Experience> CreateExperienceAsync(Experience newExperience);
        public Task<Experience> UpdateExperienceAsync(int id, Experience experience);
        public Task DeleteExperienceByIdAsync(int id);
    }
}
