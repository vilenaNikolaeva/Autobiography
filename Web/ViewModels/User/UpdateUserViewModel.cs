using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Web.Attributes;

namespace Web.ViewModels
{
    public class UpdateUserViewModel 
    {
        [Required(ErrorMessage = "Required name")]
        [MaxLength(50, ErrorMessage = "Max Length 50")]
        public string Username { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Required email")]
        [EmailAddress]
        public string Email { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string ImageSrc { get; set; }
        
        [Required]
        [MaxFileSize(10*1024*1024)]
        public IFormFile ImageFile { get; set; }
    }

}
