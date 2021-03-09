using Autobiography.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Autobiography.Data
{
    public class AutobiographyDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Skill> Skills { get; set; }


        public AutobiographyDbContext(DbContextOptions<AutobiographyDbContext> contextOptions)
            : base(contextOptions)
        {

        }
    }
}
