using Server.Infrastructure.Dto;
using Server.Infrastructure.Dto.Requests.Role;
using Server.Infrastructure.Dto.Requests.User;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using WebUiServiceClient.Common;

namespace WebUiServiceClient.User
{

    public class UserServiceClient : IUserServiceClient
    {
        HttpServices httpServices = new HttpServices();

        public async Task<UserDto> Login(string email, string password)
        {
            string uri = "api/User/Login/";

            var request = new LoginRequest
            {
                Email = email,
                Password = password
            };

            var userInDb = await httpServices.Post<UserDto, LoginRequest>(uri, request);
            
            if (userInDb == null)
            {
                throw new Exception("Nem található a felhasználó");
            }

            return userInDb;
        }

        public async Task<UserDto> RegisterUser(AddUserRequest registerUserRequest)
        {
            string uri = "api/User/Register";

            var userToDb = await httpServices.Post<UserDto, AddUserRequest>(uri, registerUserRequest);

            if (userToDb == null)
            {
                throw new Exception("Sikertelen regisztráció ez az email cím már regisztrált!!");
            }

            return userToDb;
        }

        public async Task<ClientDto> RegisterClient(AddClientRequest addClientRequest)
        {
            string uri = "api/User/RegisterClient";

            var clientToDb = await httpServices.Post<ClientDto, AddClientRequest>(uri, addClientRequest);

            if (clientToDb == null)
            {
                throw new Exception("Sikertelen regisztráció");
            }

            return clientToDb;
        }

        public async Task<UserDto> Forgot(string email)
        {
            string uri = "api/User/Forgot";

            var request = new ForgotPassword
            {
                Email = email
            };

            var emailInDb = await httpServices.Post<UserDto, ForgotPassword>(uri, request);

            if (emailInDb == null)
            {
                throw new Exception("Nincs ilyen email cím!");
            }
            return null;
        }

        public async Task<UserDto> ResetPassword(string email, string password, string token)
        { 
            string uri = "api/user/resetpassword";

            var request = new ForgotPassword
            {
                Email = email,
                Password = password,
                Token = token
            };

            var newPasswordToDb = await httpServices.Post<UserDto, ForgotPassword>(uri, request);



            if (newPasswordToDb == null)
            {
                throw new FaultException("Sikertelen jelszó visszaállítás!");
            }

            return null;
        }

        public async Task<UserDto> GetUserByEmail(string email)
        {
            string uri = "api/user/GetUserByEmail";

            var request = new UserDto
            {
                Email = email
            };

            var userInDb = await httpServices.Post<UserDto, UserDto>(uri, request);

            if (userInDb == null)
            {
                throw new Exception("Nincs ilyen user!");
            }

            return userInDb;
        }

        public async Task<List<ClientDto>> GetAllClientList()
        {
            string uri = "api/client/getallclient/";

            var clientInDb = await httpServices.Get<List<ClientDto>>(uri);

            if (clientInDb == null)
            {
                throw new Exception("Nincs Client!");
            }

            return clientInDb;
        }

        public async Task<List<StatusDto>> GetAllStatus()
        {
            string uri = "api/status/GetAllStatus";

            var statusInDb = await httpServices.Get<List<StatusDto>>(uri);

            if (statusInDb == null)
            {
                throw new Exception("A statusok nem elérhetőek!");
            }

            return statusInDb;
        }

        public async Task<List<UserDto>> GetAllUser()
        {
            string uri = "api/user/getalluser";

            var usersInDb = await httpServices.Get<List<UserDto>>(uri);

            if (usersInDb == null)
            {
                throw new Exception("Sikertelen lekérdezés!");
            }

            return usersInDb;
        }

        public async Task<bool> DeleteUserFromTeam(long id)
        {
            bool flag = false;
            
            string uri = "api/user/DeleteUserFromTeam/"+id;

            flag = await httpServices.Delete(uri);

            return flag;
        }

        public async Task<RoleDto> GetRoleTypeId(string email)
        {
            string uri = "api/user/GetRoleTypeId";

            var request = new Rolerequest
            {
                UserEmail = email
            };

            var roleInDb = await httpServices.Post<RoleDto, Rolerequest>(uri, request);

            if (roleInDb == null)
            {
                throw new Exception("Not found!");
            }

            return roleInDb;
        }

        public async Task<bool> EditUser(AddUserRequest request)
        {
            string uri = "api/user/edituser";

            var editUser = await httpServices.Put(uri, request);

            if (editUser == false)
            {
                throw new Exception("Sikertelen módosítás");
            }

            return editUser;
        }

        public async Task<bool> DeleteUser(long id)
        {
            string uri = "api/user/deleteuser/";

            var deleteUserFromDB = await httpServices.Delete(uri + id);

            if (deleteUserFromDB == false)
            {
                throw new Exception("Sikertelen törlés");
            }

            return deleteUserFromDB;
        }

        public async Task<UserDto> GetUserById(long id)
        {
            string uri = "api/user/getuserbyid/";

            var userInDb = await httpServices.Get<UserDto>(uri + id);

            if (userInDb == null)
            {
                throw new Exception("Not found");
            }

            return userInDb;
        }

        public Guid? GetPasswordResetToken()
        {
            throw new NotImplementedException();
        }

        public void SetPasswordResetToken(Guid? value)
        {
            throw new NotImplementedException();
        }
    }
}