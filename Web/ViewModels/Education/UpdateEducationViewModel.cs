using System;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class UpdateEducationViewModel
    {
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        public bool Present { get; set; }
        [Required]
        [MaxLength(250)]
        public string University { get; set; }
        [Required]
        [MaxLength(250)]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
