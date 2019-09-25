using System.ComponentModel.DataAnnotations;

namespace WebUi.Model.Login
{
    public class ForgotPasswordViewModel
    {
        [Display(Name = "Email", ResourceType = typeof(Resource))]
        [Required(ErrorMessage = "Required Email!")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Password", ResourceType = typeof(Resource))]
        [Required(ErrorMessage = "Required Password!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
   
        public string Token { get; set; }

        [Display(Name = "ConfirmPassword", ResourceType = typeof(Resource))]
        [Required(ErrorMessage = "Confirm Password is required!")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
}