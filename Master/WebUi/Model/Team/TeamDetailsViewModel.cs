using Server.Infrastructure.Dto.Responses;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Server.Infrastructure.Dto;

namespace WebUi.Model.Team
{
    public class TeamDetailsViewModel
    {
        [Required]
        public string PublicPrice { get; set; }

        [Required]
        public string PrivatePrice { get; set; }

        public string Currency { get; set; }

        [Required]
        public long  CurrencyId { get; set; }   

        [Required]
        public string TeamName { get; set; }

        public string UserName { get; set; }

        public long UserId { get; set; }

        public long  Id { get; set; }

        public long TeamId { get; set; }    

        public TeamDetailsResponseDto TeamDetails { get; set; }

        public List<TeamDetailsResponseDto> TeamDetailsList { get; set; }

        public List<CurrencyDto> CurrencyList { get; set; }
    }
}