using System;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class ExperienceViewModel
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        public bool StillWork { get; set; }
        //[Required]
        //[MaxLength(200)]
        public string JobTitle { get; set; }
        //[Required]
        //[MaxLength(200)]
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
    }
}
