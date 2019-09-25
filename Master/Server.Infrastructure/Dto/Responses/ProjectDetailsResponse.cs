using System;
using System.Collections.Generic;

namespace Server.Infrastructure.Dto.Responses
{
    public class ProjectDetailsResponse
    {
       
        public string ProjectName { get; set; }

        public DateTime? DeadLine { get; set; }

        public Nullable<short> EffortInHours { get; set; }

        public Nullable<decimal> EffortInCurrency { get; set; }
        
        public string TeamName { get; set; }

        public long TeamId { get; set; }    
        
        public string StatusName { get; set; }

        public string Clientname { get; set; }

        public long ClientId { get; set; }      

        public long Id { get; set; }

        public string  Currency { get; set; }

        public List<ProjectDetailsResponse> ProjectDetailsList { get; set; }

        public List<TeamDto> TeamList { get; set; }
    }
}