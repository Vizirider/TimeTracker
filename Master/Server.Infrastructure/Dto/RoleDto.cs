using DataAccessLayer;
using System.Collections.Generic;

namespace Server.Infrastructure.Dto
{
    public class RoleDto : EntityBaseDto
    {
        public long Id { get; set; }

        public string Key { get; set; }

        public RoleTypeEnum RoleTypeId { get; set; }
        //public List<PermissionDto> Permissions { get; set; }
    }
}