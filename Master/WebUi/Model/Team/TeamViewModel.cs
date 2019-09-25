using Server.Infrastructure.Dto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebUi.Model.Team
{
    public class TeamViewModel 
    {
        [Required]
        [Display(Name = "Team Name")]
        public string Name { get; set; }

        public long Id { get; set; }

        public List<TeamDto> TeamList { get; set; }
    }
}