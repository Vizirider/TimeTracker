using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Infrastructure.Dto;
using Server.Infrastructure.Dto.Requests.User;
using Server.Infrastructure.Dto.Responses;

namespace WebUiServiceClient.Client
{
    public interface IClientServicClient
    {
        Task<ClientDetailsResponse> GetDetailsClientById(long id);

        Task<ClientDto> RegisterClient(AddClientRequest addClientRequest);

        Task<List<ClientDto>> GetAllClientList();

        Task<ClientDto> GetClientById(long id);

        Task<bool> EditClient(long id, string website, long teamId, string clientName);

        Task<bool> DeleteClient(long id);

        Task<List<ClientDto>> GetAllClientByUser(string email);

    }
}