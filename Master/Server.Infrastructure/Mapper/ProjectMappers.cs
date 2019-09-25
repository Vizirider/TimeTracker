using DataAccessLayer;
using Server.Infrastructure.Dto;

namespace Server.Infrastructure.Mapper
{
    public static class ProjectMappers
    {
        public static ProjectDto Map(this Project source)
        {
            var target = new ProjectDto()
            {
                Name = source.Name,
                DeadLine = source.DeadLine,
                EffortInHours = source.EffortInHours,
                EffortInCurrency = source.EffortInCurrency,
                TeamId = source.TeamId,
                StatusId = source.StatusId,
                ClientId = source.ClientId,
                Id = source.Id,
                CurrencyId = source.CurrencyId
            };

            return target;
        }
    }
}
