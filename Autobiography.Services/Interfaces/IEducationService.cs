using Autobiography.Domain;
using System.Threading.Tasks;

namespace Autobiography.Services.Interfaces
{
    public interface IEducationService
    {
        public Task<Education> FindByIdAsync(int id);
        public Task<Education> CreateEducationAsync(Education newEducation);
        public Task<Education> UpdateEducationAsync(int id, Education education);
        public Task DeleteEducationByIdAsync(int id);
    }
}
