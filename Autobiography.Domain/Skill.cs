using System.ComponentModel.DataAnnotations;

namespace Autobiography.Domain
{
    public class Skill
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public int Level { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

    }
}
