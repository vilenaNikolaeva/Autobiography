using Autobiography.Domain;
using System.Threading.Tasks;

namespace Autobiography.Services.Interfaces
{
    public interface ILanguageService
    {
         Task<Language> FindByIdAsync(int id);
         Task<Language> CreateLanguageAsync(Language newLanguage);
         Task<Language> UpdateLanguageAsync(int id, Language language);
         Task DeleteLanguageByIdAsync(int id);

    }
}
