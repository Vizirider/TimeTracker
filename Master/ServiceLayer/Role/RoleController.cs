using BusinessLogicLayer.Role;
using Server.Infrastructure.Dto;
using Server.Infrastructure.Dto.Requests.Role;
using Server.Infrastructure.Mapper;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Web.Http;

namespace ServiceLayer.Role
{
    public class RoleController : ApiController
    {
        private static readonly RoleLogic _roleLogic = new RoleLogic();

        [HttpPost]
        public bool IsPermmision(int userId, string key)
        {
            bool flag = false;
            try
            {
                flag = _roleLogic.IsPermmision(userId, key);
                return flag;
            }
            catch (Exception e)
            {
                throw new FaultException("Váratlan hiba történt a Authorisation lekérdezése során.");
            }
        }

        [HttpGet]
        public List<RoleDto> GetAllRole()
        {
            try
            {
                return _roleLogic.GetAllRole();
            }
            catch (Exception e)
            {
                throw new FaultException("Not founded!");
            }
     
        }

        [HttpPut]
        public bool EditRole(Rolerequest request)
        {
            try
            {
                return _roleLogic.EditRole(request.Id, request.Key, request.RoleTypeId);
            }
            catch (Exception e)
            {
               throw new FaultException("sikertelen!");
            }
        }

        [HttpDelete]
        public bool DeleteRole(long id)
        {
            try
            {
                return _roleLogic.DelelteRole(id);
            }
            catch (Exception e)
            {
                throw new FaultException("Sikertelen");
            }
        }

        [HttpPost]
        public RoleDto AddRole(Rolerequest request)
        {
            try
            {
                return _roleLogic.AddRole(request).Map();
            }
            catch (Exception e)
            {
                throw new FaultException("Sikertelen");
            }
        }

        [HttpGet]
        public RoleDto GetRoleById(long id)
        {
            try
            {
                return _roleLogic.GetRoleById(id).Map();
            }
            catch (Exception e)
            {
                throw new FaultException("Not found!");
            }
        }
    }
}
