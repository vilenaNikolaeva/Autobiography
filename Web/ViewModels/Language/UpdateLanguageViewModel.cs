using System;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class UpdateLanguageViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [Range(1, 100)]
        public int Level { get; set; }
    }
}
