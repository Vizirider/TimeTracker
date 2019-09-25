using System.ComponentModel.DataAnnotations;

namespace WebUi.Model.Login
{
    public class LoginViewModel
    {
        [Display(Name = "Password", ResourceType = typeof(Resource))]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Email", ResourceType = typeof(Resource))]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}