using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Autobiography.Domain
{
    public class Skill
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

    }
}
