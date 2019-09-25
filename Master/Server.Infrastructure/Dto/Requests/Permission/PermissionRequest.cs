using DataAccessLayer;

namespace Server.Infrastructure.Dto.Requests.Permission
{
    public class PermissionRequest
    {
        public string Key { get; set; }

        public PermissionTypeEnum PermissionTypeId { get; set; }

        public long Id { get; set; }
    }
}