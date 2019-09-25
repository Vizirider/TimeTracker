using DataAccessLayer;
using Server.Infrastructure.Dto;

namespace Server.Infrastructure.Mapper
{
    public static class PermissionMappers
    {
        public static PermissionDto Map(this Permission source)
        {
            var target = new PermissionDto
            {
                Id = source.Id,
                Key = source.Key,
                PermissionTypeId = source.PermissionTypeId
            };

            return target;
        }
    }
}