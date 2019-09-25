using DataAccessLayer;
using Server.Infrastructure.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebUiServiceClient.Role
{
    public interface IRoleServiceClient
    {
        Task<List<RoleDto>> GetAllRole();

        Task<RoleDto> GetRoleById(long id);

        Task<bool> EditRole(long id, string key, RoleTypeEnum roleType);

        Task<bool> DeleteRole(long id);

        Task<RoleDto> AddRole(string key, RoleTypeEnum roleType);

    }
}