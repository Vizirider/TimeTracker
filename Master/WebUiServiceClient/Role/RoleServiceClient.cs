using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer;
using Server.Infrastructure.Dto;
using Server.Infrastructure.Dto.Requests.Role;
using WebUiServiceClient.Common;

namespace WebUiServiceClient.Role
{
    public class RoleServiceClient : IRoleServiceClient
    {
        HttpServices httpServices= new HttpServices();

        public async Task<RoleDto> AddRole(string key, RoleTypeEnum roleType)
        {
            string uri = "api/role/addrole";

            var request = new Rolerequest
            {
                Key = key,
                RoleTypeId = roleType
            };

            var addRole = await httpServices.Post<RoleDto, Rolerequest>(uri, request);

            if (addRole == null)
            {
                throw new Exception(" Create role did not succesfull");
            }

            return addRole;
        }

        public async Task<bool> DeleteRole(long id)
        {
            string uri = "api/role/deleterole/";

            var deleteRole = await httpServices.Delete(uri + id);

            if (deleteRole == false)
            {
                throw new Exception("Delete role did not successful ");
            }

            return deleteRole;
        }

        public async Task<bool> EditRole(long id, string key, RoleTypeEnum roleType)
        {
            string uri = "api/role/editrole";

            var request= new Rolerequest
            {
                Id = id,
                Key = key,
                RoleTypeId = roleType
            };

            var editRole = await httpServices.Put(uri, request);

            if (editRole == false)
            {
                throw new Exception("Role edit did not succesful");
            }

            return editRole;
        }

        public async Task<List<RoleDto>> GetAllRole()
        {
            string uri = "api/role/getallrole";

            var rolesInDb = await httpServices.Get<List<RoleDto>>(uri);

            if (rolesInDb == null)
            {
                throw new Exception("Not found!");
            }

            return rolesInDb;
        }

        public async Task<RoleDto> GetRoleById(long id)
        {
            string uri = "api/role/GetRoleById/";

            var roleInDb = await httpServices.Get<RoleDto>(uri + id);

            if (roleInDb == null)
            {
                throw new Exception("Not found");
            }

            return roleInDb;
        }
    }
}