using System;
using System.ComponentModel.DataAnnotations;

namespace Autobiography.Domain
{
    public class Language
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [Range(1, 10)]
        public int Level { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

    }
}
