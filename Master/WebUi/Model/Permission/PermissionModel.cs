using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataAccessLayer;
using Server.Infrastructure.Dto;

namespace WebUi.Model.Permission
{
    public class PermissionModel
    {
        [Required]
        public string Key { get; set; }

        [Required]
        public PermissionTypeEnum PermissionTypeId { get; set; }

        public long Id { get; set; }

        public List<PermissionDto> PermissionList { get; set; }
    }
}