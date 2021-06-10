using Autobiography.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class SkillViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Level { get; set; }
        public string UserId { get; set; }
    }
}
