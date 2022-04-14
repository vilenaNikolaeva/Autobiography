using Autobiography.Data.Repositories.Interfaces;
using Autobiography.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autobiography.Data.Repositories
{
    public class CoverLetterRepository : BaseRepositoryContext, ICoverLetterRepository
    {
        public CoverLetterRepository(AutobiographyDbContext context) : base(context)
        {
        }
        public async Task<CoverLetter> GetCoverLetterByUserIdAsync(string userId)
        {
            var letter = await this.context.Users.Select(x => x.CoverLetter).Where(x => x.UserId == userId).FirstOrDefaultAsync();
            return letter;
        }
        public async Task<CoverLetter> CreateCoverLetterByUserIdAsync(string userId)
        {
            var letter = await GetCoverLetterByUserIdAsync(userId);
            if (letter != null)
            {
                return null;
            }
            var user = await this.context.Users.FindAsync(userId);
            user.CoverLetter = new CoverLetter
            {
                UserId = userId
            };
            await this.context.SaveChangesAsync();
            return letter;
        }
        public  async Task<CoverLetter> UpdateCoverLetterAsync(CoverLetter letter)
        {
            var userLetter = await this.GetCoverLetterByUserIdAsync(letter.UserId);
            userLetter.Link = letter.Link;
            userLetter.RecepientName = letter.RecepientName;
            userLetter.RecepientPhone= letter.RecepientPhone;
            userLetter.RecepientCompany = letter.RecepientCompany;
            userLetter.RecepientDepartment = letter.RecepientDepartment;
            userLetter.RecepientEmail = letter.RecepientEmail;
            userLetter.Presentation = letter.Presentation;
            userLetter.AppelTo = letter.AppelTo;
            userLetter.Date = letter.Date;

            await this.context.SaveChangesAsync();
            return letter;
        }
        public async Task DeleteCoverLetterByIdAsync(string userId)
        {
            var userLetter = await this.GetCoverLetterByUserIdAsync(userId);
            userLetter.Link = null;
            userLetter.RecepientName = null;
            userLetter.RecepientPhone = null;
            userLetter.RecepientCompany = null;
            userLetter.RecepientDepartment = null;
            userLetter.RecepientEmail = null;
            userLetter.Presentation = null;
            userLetter.AppelTo = null;
            userLetter.Date = new DateTime();
            await this.context.SaveChangesAsync();
        }
    }
}
