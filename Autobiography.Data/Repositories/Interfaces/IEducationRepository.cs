using Autobiography.Domain;
using System.Threading.Tasks;

namespace Autobiography.Data.Repositories.Interfaces
{
    public interface IEducationRepository
    {
        public Task<Education> FindByIdAsync(int id);
        public Task<Education> CreateEducationAsync(Education newEducation);
        public Task<Education> UpdateEducationAsync(int id, Education education);
        public Task DeleteEducationByIdAsync(int id);
      
    }
}
