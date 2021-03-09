using Autobiography.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Autobiography.Data
{
    public class LanguageRepository : BaseRepositoryContext, ILanguageRepository
    {
        public LanguageRepository(AutobiographyDbContext context)
            : base(context)
        {
        }

        public async Task<Language> FindByIdAsync(int id)
        {
            return await this.context.Languages.FindAsync(id);
        }
        public async Task<Language> CreateLanguageAsync(Language newLanguage)
        {
            await this.context.Languages.AddAsync(newLanguage);
            await this.context.SaveChangesAsync();

            return newLanguage;
        }

        public async Task DeleteLanguageByIdAsync(int id)
        {
            var language = await this.FindByIdAsync(id);
            this.context.Languages.Remove(language);
            await this.context.SaveChangesAsync();
        }

        public async Task<Language> UpdateLanguageAsync(int id, Language language)
        {
            var LanguageForUpdate = await this.FindByIdAsync(id);

            LanguageForUpdate.Name = language.Name;

            this.context.Languages.Update(LanguageForUpdate);
            await this.context.SaveChangesAsync();
            return LanguageForUpdate;
        }
    }
}
