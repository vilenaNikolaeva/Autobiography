using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Autobiography.Domain
{
    public class Language
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [Range(1, 10)]
        public int Level { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

    }
}
