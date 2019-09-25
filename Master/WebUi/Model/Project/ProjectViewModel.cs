using Server.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Server.Infrastructure.Dto.Responses;

namespace WebUi.Model.Project
{
    public class ProjectViewModel
    {
        [Display(Name = "Projects", ResourceType = typeof(Resource))]
        [Required]
        public string Name { get; set; }

        [Display(Name = "DeadLine", ResourceType = typeof(Resource))]
        [Required]
        public DateTime? DeadLine { get; set; }

        [Display(Name = "EffortInHours", ResourceType = typeof(Resource))]
        [DisplayFormat(DataFormatString = "{0:Óra}", ApplyFormatInEditMode = true)]
        [Required]
        public Nullable<short> EffortInHours { get; set; }

        [Display(Name = "EffortInCurrency", ResourceType = typeof(Resource))]
        [Required]
        public Nullable<decimal> EffortInCurrency { get; set; }

        [Display(Name = "TeamId", ResourceType = typeof(Resource))]
        [Required]
        public long TeamId { get; set; }

        [Display(Name = "StatusId", ResourceType = typeof(Resource))]
        [Required]
        public long StatusId { get; set; }

        [Display(Name = "ClientId", ResourceType = typeof(Resource))]
        [Required]
        public long ClientId { get; set; }

        [Display(Name = "Currency")]
        [Required]
        public long CurrencyId { get; set; }

        public long Id { get; set; }

        public string TeamName { get; set; }

        public string  CurrencyCode { get; set; }   

        public ProjectDto Project { get; set; }

        public ProjectDetailsResponse ProjectDetails { get; set; }

        public List<TeamDto> TeamList { get; set; }

        public List<StatusDto> StatusList { get; set; }

        public List<ClientDto> ClientList { get; set; }

        public List<ProjectDto> ProjectList { get; set; }

        public List<ProjectDetailsResponse> TeamListForTeam { get; set; }

        public List<CurrencyDto> CurrencyList { get; set; }

        public List<TodoDto> AllTodoList { get; set; }

    }
}