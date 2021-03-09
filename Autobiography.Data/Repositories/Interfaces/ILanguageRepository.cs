using Autobiography.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autobiography.Data
{
    public interface ILanguageRepository
    {
        public Task<Language> FindByIdAsync(int id);
        public Task<Language> CreateLanguageAsync(Language newLanguage);
        public Task<Language> UpdateLanguageAsync(int id, Language language);
        public Task DeleteLanguageByIdAsync(int id);


    }
}
