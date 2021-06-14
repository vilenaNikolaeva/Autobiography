using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Autobiography.Domain
{
    public class Education
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        public bool Present { get; set; }

        [Required]
        [MaxLength(250)]
        public string University { get; set; }
        [Required]
        [MaxLength(250)]
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
