using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataAccessLayer;
using Server.Infrastructure.Dto;

namespace WebUi.Model.Role
{
    public class RoleModel
    {
        public long Id { get; set; }

        [Required]
        public string Key { get; set; }

        [Required]
        public RoleTypeEnum RoleTypeId { get; set; }

        public List<RoleDto> RoleList { get; set; }
    }
}