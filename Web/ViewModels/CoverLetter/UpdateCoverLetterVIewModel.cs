using System;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.CoverLetter
{
    public class UpdateCoverLetterVIewModel
    {
        public string Link { get; set; }
        public string RecepientName { get; set; }
        public string RecepientEmail { get; set; }
        public string RecepientPhone { get; set; }
        public string RecepientDepartment { get; set; }
        public string RecepientCompany { get; set; }
        public string AppelTo { get; set; }
        public string Presentation { get; set; }
        public string Regardless { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public string UserId { get; set; }
    }
}
