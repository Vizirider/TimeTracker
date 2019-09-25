using System.ComponentModel.DataAnnotations;
using Server.Infrastructure.Dto.Requests.User;

namespace WebUi.Model.Register
{
    public class AddUserRequestView : AddUserRequest
    {
        [Display(Name = "Name", ResourceType = typeof(Resource))]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Email", ResourceType = typeof(Resource))]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "ConfirmEmail", ResourceType = typeof(Resource))]
        [Required]
        [EmailAddress]
        [Compare("Email")]
        public string ConfirmEmail { get; set; }

        [Display(Name = "Password", ResourceType = typeof(Resource))]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "ConfirmPassword", ResourceType = typeof(Resource))]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Phone", ResourceType = typeof(Resource))]
        [Required]
        public string Phone { get; set; }

    }
}