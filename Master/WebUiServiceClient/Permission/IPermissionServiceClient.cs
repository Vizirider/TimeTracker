using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer;
using Server.Infrastructure.Dto;

namespace WebUiServiceClient.Permission
{
    public interface IPermissionServiceClient
    {
        Task<List<PermissionDto>> GetAllPermission();

        Task<PermissionDto> AddPermission(long id, string key, PermissionTypeEnum permissionType);

        Task<bool> EditPermission(long id, string key, PermissionTypeEnum permissionType);

        Task<bool> DeletePermission(long id);

        Task<PermissionDto> GetPermissionById(long id);

    }
}