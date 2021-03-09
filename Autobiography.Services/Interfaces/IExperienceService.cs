using Autobiography.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Autobiography.Services.Interfaces
{
    public interface IExperienceService
    {
        public Task<Experience> FindByIdAsync(int id);
        public Task<Experience> CreateExperinceAsync(Experience newExperience);
        public Task<Experience> UpdateExperienceAsync(int id, Experience experience);
        public Task DeleteExperienceByIdAsync(int id);
    }
}
