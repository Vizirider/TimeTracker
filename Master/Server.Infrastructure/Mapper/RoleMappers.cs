using DataAccessLayer;
using Server.Infrastructure.Dto;

namespace Server.Infrastructure.Mapper
{
    public static class RoleMappers
    {
        public static RoleDto Map(this Role source)
        {
            var target = new RoleDto
            {
                Id = source.Id,
                Key = source.Key,
                RoleTypeId = source.RoleTypeId
            };
            return target;
        }
    }
}
