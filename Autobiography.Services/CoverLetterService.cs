using Autobiography.Data.Repositories.Interfaces;
using Autobiography.Domain;
using Autobiography.Services.Interfaces;
using System.Threading.Tasks;

namespace Autobiography.Services
{
    public class CoverLetterService : ICoverLetterService
    {
        private readonly ICoverLetterRepository coverLetterRepository;

        public CoverLetterService(ICoverLetterRepository coverLetterRepository)
        {
            this.coverLetterRepository = coverLetterRepository;
        }

        public async Task<CoverLetter> CreateCoverLetterByUserIdAsync(string userId)
        {
            return  await this.coverLetterRepository.CreateCoverLetterByUserIdAsync(userId);
        }

        public async Task DeleteCoverLetterByIdAsync(string userId)
        {
            await this.coverLetterRepository.DeleteCoverLetterByIdAsync(userId);
        }

        public async Task<CoverLetter> GetCoverLetterByUserIdAsync(string userId)
        {
            return await this.coverLetterRepository.GetCoverLetterByUserIdAsync(userId);
        }

        public async Task<CoverLetter> UpdateCoverLetterAsync(CoverLetter letter)
        {
            return await this.coverLetterRepository.UpdateCoverLetterAsync(letter);
        }
    }
}
