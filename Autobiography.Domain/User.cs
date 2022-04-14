using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Autobiography.Domain
{
    public class User : IdentityUser
    {

        public string ImageName { get; set; }
        public string ImageSrc { get; set; }
        public string Address { get; set; }
        public string JobTitle { get; set; }
        public string Link { get; set; }
        public string OtherConnections { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public bool IsItPublic { get; set; }
        public string CvTemplate { get; set; }
        public string ClTemplate { get; set; }
        public CoverLetter CoverLetter { get; set; } 
        public ICollection<Language> Languages { get; set; }
        public ICollection<Skill> Skills { get; set; }
        public ICollection<Education> Educations { get; set; }
        public ICollection<Experience> Experiences { get; set; }
    }
}
