using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class CreateSkillViewModel
    {
        [Required(ErrorMessage = "Skill title is required")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Skill level is required")]
        public int Level { get; set; }
        public string UserId { get; set; }
    }
}
