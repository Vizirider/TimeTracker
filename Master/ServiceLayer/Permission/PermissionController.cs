using BusinessLogicLayer.Permission;
using Server.Infrastructure.Dto;
using Server.Infrastructure.Dto.Requests.Permission;
using Server.Infrastructure.Mapper;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Web.Http;


namespace ServiceLayer.Permission
{
    public class PermissionController : ApiController
    {
        private static readonly PermissionLogic _permissionLogic = new PermissionLogic();

        [HttpGet]
        public List<PermissionDto> PermissionList()
        {
            try
            {
                return _permissionLogic.GetAllPermission();
            }
            catch (Exception e)
            {
                throw new FaultException("Not founded!");
            }
        }

        [HttpPost]
        public PermissionDto AddPermission(PermissionRequest request)
        {
            try
            {
                return _permissionLogic.AddPermission(request).Map();
            }
            catch (Exception e)
            {
                throw new FaultException("Sikertelen");
            }
        }

        [HttpPut]
        public bool EditPermission(PermissionRequest request)
        {
            try
            {
                return _permissionLogic.EditPermission(request.Id, request.Key, request.PermissionTypeId);
            }
            catch (Exception e)
            {
                throw new FaultException(e.Message);
            }
        }

        [HttpDelete]
        public bool DeletePermission(long id)
        {
            try
            {
                return _permissionLogic.DeletePermission(id);
            }
            catch (Exception e)
            {
                throw new FaultException("Sikertelen törlés");
            }
        }

        [HttpGet]
        public PermissionDto GetPermissionById(long id)
        {
            try
            {
                return _permissionLogic.GetPermissionById(id).Map();
            }
            catch (Exception e)
            {
                throw new FaultException("The permission list was not founded!");
            }
        }

    }
}
