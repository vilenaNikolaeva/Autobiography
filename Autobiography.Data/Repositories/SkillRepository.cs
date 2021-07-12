using Autobiography.Data.Repositories.Interfaces;
using Autobiography.Domain;
using System.Threading.Tasks;

namespace Autobiography.Data.Repositories
{
    public class SkillRepository : BaseRepositoryContext, ISkillRepository
    {
        public SkillRepository(AutobiographyDbContext context)
            : base(context)
        {
        }

        public async Task<Skill> FindByIdAsync(int id)
        {
            return await this.context.Skills.FindAsync(id);
        }

        public async Task<Skill> CraeteSkillAsync(Skill newSkill)
        {
            await this.context.Skills.AddAsync(newSkill);
            await this.context.SaveChangesAsync();
            return newSkill;
        }

        public async Task DeleteSkillByIdAsync(int id)
        {
            var skill = await this.FindByIdAsync(id);
            this.context.Skills.Remove(skill);
            await this.context.SaveChangesAsync();
        }

        public async Task<Skill> UpdateSkillAsync(int id, Skill skill)
        {
            var skillForUpdate = await this.FindByIdAsync(id);

            skillForUpdate.Title = skill.Title;
            skillForUpdate.Level = skill.Level;

            this.context.Skills.Update(skillForUpdate);
            await this.context.SaveChangesAsync();
            return skillForUpdate;
        }

      
    }
}
