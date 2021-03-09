using Autobiography.Domain;
using System;
using System.Collections.Generic;
using System.Text;
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
