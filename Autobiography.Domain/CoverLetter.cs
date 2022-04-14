using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autobiography.Domain
{
    public class CoverLetter
    {
        public int Id { get; set; }
        public string  Link { get; set; }
        public string RecepientName { get; set; }
        public string  RecepientEmail { get; set; }
        public string RecepientPhone { get; set; }
        public string RecepientDepartment { get; set; }
        public string RecepientCompany { get; set; }
        public string  AppelTo { get; set; }
        public string Presentation { get; set; }
        public string Regardless{ get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

    }
}
