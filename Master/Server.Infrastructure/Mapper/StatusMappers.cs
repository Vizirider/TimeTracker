using DataAccessLayer;
using Server.Infrastructure.Dto;

namespace Server.Infrastructure.Mapper
{
    public static class StatusMappers
    {
        public static StatusDto Map(this Status source)
        {
            var target = new StatusDto
            {
                Name = source.Name,
                StateTypeId = source.StateTypeId,
                Id = source.Id
            };

            return target;
        }
    }
}
