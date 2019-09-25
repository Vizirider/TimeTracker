using System;

namespace Server.Infrastructure.Dto.Requests.Project
{
    public class ProjectRequest
    {
        public string Name { get; set; }

        public DateTime? DeadLine { get; set; }

        public Nullable<short> EffortInHours { get; set; }

        public Nullable<decimal> EffortInCurrency { get; set; }

        public long TeamId { get; set; }

        public long StatusId { get; set; }

        public long ClientId { get; set; }

        public long Id { get; set; }

        public string UserEmail { get; set; }

        public long  CurrencyId { get; set; }   
    }
}
