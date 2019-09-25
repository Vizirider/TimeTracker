using DataAccessLayer;

using Server.Infrastructure.Dto;

namespace Server.Infrastructure.Mapper
{
    public static class TeamMappers
    {
        public static TeamDto Map(this Team source)
        {
            var target =  new TeamDto
            {
                Name = source.Name,

                Id = source.Id
            };

            return target;
        }
    }
}
