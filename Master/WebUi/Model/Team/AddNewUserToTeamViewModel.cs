using Server.Infrastructure.Dto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebUi.Model.Team
{
    public class AddNewUserToTeamViewModel
    {
        [Required]
        public string PublicPrice { get; set; }

        [Required]
        public string PrivatePrice { get; set; }

        [Required]
        public long CurrencyId { get; set; }

        [Required]
        public long TeamId { get; set; }

        [Required]
        public long UserId { get; set; }

        public long Id { get; set; }

        public List<UserDto> UserList { get; set; }

        public List<TeamDto> TeamList { get; set; }

        public List<CurrencyDto> CurrencyList { get; set; }

    }
}