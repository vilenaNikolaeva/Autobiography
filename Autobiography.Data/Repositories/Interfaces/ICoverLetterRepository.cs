using Autobiography.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autobiography.Data.Repositories.Interfaces
{
    public interface ICoverLetterRepository
    {
        public Task<CoverLetter> CreateCoverLetterByUserIdAsync(string userId);
        public Task<CoverLetter> GetCoverLetterByUserIdAsync(string userId);
        public Task<CoverLetter> UpdateCoverLetterAsync(CoverLetter letter);
        public Task DeleteCoverLetterByIdAsync(string userId);
    }
}
