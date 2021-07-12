using Autobiography.Data;
using Autobiography.Domain;
using Autobiography.Services.Interfaces;
using System.Threading.Tasks;

namespace Autobiography.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepository languageRepository;
        public LanguageService(ILanguageRepository languageRepository)
        {
            this.languageRepository = languageRepository;
        }

        public async Task<Language> FindByIdAsync(int id)
        {
            return await this.languageRepository.FindByIdAsync(id);
        }

        public async Task<Language> CreateLanguageAsync(Language newLanguage)
        {
            await this.languageRepository.CreateLanguageAsync(newLanguage);
            return newLanguage;
        }

        public async Task<Language> UpdateLanguageAsync(int id, Language language)
        {
            var updatedLanguage = await this.languageRepository.UpdateLanguageAsync(id, language);
            return updatedLanguage;
        }

        public async Task DeleteLanguageByIdAsync(int id)
        {
            await this.languageRepository.DeleteLanguageByIdAsync(id);
        }

    }
}
