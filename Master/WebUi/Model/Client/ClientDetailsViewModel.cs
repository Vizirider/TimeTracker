using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Server.Infrastructure.Dto;
using Server.Infrastructure.Dto.Responses;

namespace WebUi.Model.Client
{
    public class ClientDetailsViewModel 
    {
        public long Id { get; set; }

        [Display(Name = "ClientName", ResourceType = typeof(Resource))]
        [Required]
        public string ClientName { get; set; }

        [Display(Name = "Website", ResourceType = typeof(Resource))]
        [Required]
        public string Website { get; set; }

        [Display(Name = "TeamName", ResourceType = typeof(Resource))]
        public string TeamName { get; set; }

        [Display(Name = "TeamId", ResourceType = typeof(Resource))]
        [Required]
        public long  TeamId { get; set; }

        public ClientDetailsResponse ClientDetails { get; set; }

        public List<ClientDetailsResponse> ClientList { get; set; }

        public List<TeamDto> TeamList { get; set; }
    }
}