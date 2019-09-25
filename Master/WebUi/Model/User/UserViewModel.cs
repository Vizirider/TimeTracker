using Server.Infrastructure.Dto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebUi.Model.User
{
    public class UserViewModel 
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public long Id { get; set; }
        
        [Required]
        public string Phone { get; set; }

        public long RoleId { get; set; }

        public string RoleName { get; set; }

        public List<UserDto> UserList { get; set; }

        public List<RoleDto> RoleList { get; set; }
        public string Token { get; set; }
    }
}