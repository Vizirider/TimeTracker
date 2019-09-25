namespace ServiceLayer.User
{
    using System.Collections.Generic;
    using BusinessLogicLayer.Role;
    using Server.Infrastructure.Dto.Requests.Role;
    using BusinessLogicLayer.User;
    using Server.Infrastructure.Dto;
    using Server.Infrastructure.Dto.Requests.User;
    using Server.Infrastructure.Mapper;
    using System;
    using System.ServiceModel;
    using System.Web.Http;


    public class UserController : ApiController
    {
        private static readonly UserLogic _userLogic = new UserLogic();
        private static readonly RoleLogic _roleLogic = new RoleLogic();

        [HttpPost]
        public UserDto Login(ForgotPassword request)
        {
            try
            {
                return _userLogic.GetUserByPasswordAndEmail(request.Password, request.Email)
                    .Map();
            }
            catch (Exception e)
            {
                // todo : log exception
                throw new FaultException("Sikertelen bejelentkezés.");
            }
        }

        [HttpPost]
        public UserDto Register(AddUserRequest userUserRequest)
        {
            try
            {
                return _userLogic.AddUser(userUserRequest.Name, userUserRequest.Email, userUserRequest.Password,
                        userUserRequest.Token, userUserRequest.Phone)
                    .Map(); 
            }
            catch (Exception e)
            {
                // todo : log exception
                throw new FaultException("Sikertelen regisztráció.");
            }
        }

        [HttpPost]
        public ClientDto RegisterClient(AddClientRequest request)
        {
            try
            {
                return _userLogic.AddClient(request.Name, request.Email, request.Password, request.Phone, request.Token,
                        request.TeamId, request.Website)
                    .Map();
            }
            catch (Exception e)
            {
                // todo : log exception
                throw new FaultException("Sikertelen regisztráció.");
            }
        }

        [HttpPost]
        public UserDto GetUserByEmail(AddClientRequest userRequest)
        {
            try
            {
                var result = _userLogic.GetUserbyEmail(userRequest.Email).Map();
                return result;
            }
            catch (Exception e)
            {
                throw new FaultException("Sikertelen User lekérdezés!");
            }
        }

        [HttpPost]
        public UserDto Forgot(ForgotPassword request)
        {
            try
            {
                return _userLogic.ForgotPwd(request.Email).Map();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost]
        public UserDto ResetPassword(ForgotPassword request)
        {
            try
            {
                return _userLogic.ResetPassword(request.Email, request.Password).Map();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpGet]
        public List<UserDto> GetAllUser()
        {
            try
            {
                return _userLogic.GetAllUser();
            }
            catch (Exception e)
            {
                throw new FaultException("Sikertelen User lekérdezés!");
            }
        }

        [HttpDelete]
        public bool DeleteUserFromTeam(long id)
        {
            try
            {
                return _userLogic.DeleteUserFromTeam(id);
            }
            catch (Exception e)
            {
                throw new FaultException("Sikertelen törlés!");
            }
        }

        [HttpPost]
        public RoleDto GetRoleTypeId(Rolerequest rolerequest)
        {
            try
            {
                return _roleLogic.GetRoleTypeId(rolerequest.UserEmail).Map();
            }
            catch (Exception e)
            {
                throw new FaultException("Not Found");
            }
        }

        [HttpPut]
        public bool EditUser(EditUserRequest request)
        {
            try
            {
                return _userLogic.EditUser(request.Id, request.Name, request.Email, request.Password, request.Phone,
                    request.RoleId);
            }
            catch (Exception e)
            {
                throw new FaultException("Sikertelen módosítás");
            }
        }

        [HttpDelete]
        public bool DeleteUser(long id)
        {
            try
            {
                return _userLogic.DeleteUser(id);
            }
            catch (Exception e)
            {
                throw new FaultException("Sikertelen törlés!");
            }
        }

        [HttpGet]
        public UserDto GetUserById(long id)
        {
            try
            {
                return _userLogic.GetUserById(id);
            }
            catch (Exception e)
            {
                throw new FaultException("Not Found");
            }
        }
    }
}