using Autobiography.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class CreateSkillViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public string UserId { get; set; }
    }
}
