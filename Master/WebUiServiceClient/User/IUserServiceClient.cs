using Server.Infrastructure.Dto;
using Server.Infrastructure.Dto.Requests.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebUiServiceClient.User
{
    public interface IUserServiceClient
    {
        Task<UserDto> Login(string email, string password);

        Task<UserDto> RegisterUser(AddUserRequest registerUserUserRequest);

        Task<ClientDto> RegisterClient(AddClientRequest addClientRequest);

        Task<UserDto> Forgot(string email);

        Task<UserDto> ResetPassword(string email, string password, string token);

        Guid? GetPasswordResetToken();

        void SetPasswordResetToken(Guid? value);

        Task<UserDto> GetUserByEmail(string email);

        Task<List<ClientDto>> GetAllClientList();

        Task<List<StatusDto>> GetAllStatus();

        Task<List<UserDto>> GetAllUser();

        Task<bool> DeleteUserFromTeam(long id);

        Task<RoleDto> GetRoleTypeId(string email);

        Task<bool> EditUser(AddUserRequest request);

        Task<bool> DeleteUser(long id);

        Task<UserDto> GetUserById(long id);
    }
}
