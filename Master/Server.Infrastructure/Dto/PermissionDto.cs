using DataAccessLayer;

namespace Server.Infrastructure.Dto
{
    public class PermissionDto : EntityBaseDto
    {
        public string Key { get; set; }

        public PermissionTypeEnum PermissionTypeId { get; set; }

        public long Id { get; set; }
    }
}
