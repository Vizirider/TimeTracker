using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer;
using Server.Infrastructure.Dto;
using Server.Infrastructure.Dto.Requests.Permission;
using WebUiServiceClient.Common;

namespace WebUiServiceClient.Permission
{
    public class PermissionServiceClient : IPermissionServiceClient
    {
        private HttpServices httpServices = new HttpServices();

        public async Task<PermissionDto> AddPermission(long id, string key, PermissionTypeEnum permissionType)
        {
            string uri = "api/permission/addpermission";
            var request = new PermissionRequest
            {
                Id = id,
                Key = key,
                PermissionTypeId = permissionType
            };

            var addPermissionToDb = await httpServices.Post<PermissionDto, PermissionRequest>(uri, request);

            if (addPermissionToDb == null)
            {
                throw new Exception("Save the new permission did not successful!");
            }

            return addPermissionToDb;
        }

        public async Task<bool> DeletePermission(long id)
        {
            string uri = "api/permission/deletepermission/";

            var deletePermissionFromDb = await httpServices.Delete(uri + id);

            if (deletePermissionFromDb == false)
            {
                throw new Exception("Permission did not deleted!");
            }

            return deletePermissionFromDb;
        }

        public async Task<bool> EditPermission(long id, string key, PermissionTypeEnum permissionType)
        {
            string uri = "api/permission/editpermission";

            var request = new PermissionRequest
            {
                Id = id,
                Key = key,
                PermissionTypeId = permissionType
            };

            var editPermissiontoDb = await httpServices.Put(uri, request);

            if (editPermissiontoDb == false)
            {
                throw new Exception("The permission edit did not successful!");
            }

            return editPermissiontoDb;
        }

        public async Task<List<PermissionDto>> GetAllPermission()
        {
            string uri = "api/permission/PermissionList";

            var permissionListInDB = await httpServices.Get<List<PermissionDto>>(uri);

            if (permissionListInDB == null)
            {
                throw new Exception("The permission list not founded!");
            }

            return permissionListInDB;
        }

        public async Task<PermissionDto> GetPermissionById(long id)
        {
            string uri = "api/permission/getpermissionbyid/";

            var permissionInDb = await httpServices.Get<PermissionDto>(uri + id);

            if (permissionInDb == null)
            {
                throw new Exception("Not found!");
            }

            return permissionInDb;
        }
    }
}