using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels.User
{
    public class LoginUserViewModel
    {
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
