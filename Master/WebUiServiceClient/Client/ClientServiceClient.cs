using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Infrastructure.Dto;
using Server.Infrastructure.Dto.Requests.Client;
using Server.Infrastructure.Dto.Requests.User;
using Server.Infrastructure.Dto.Responses;
using WebUiServiceClient.Common;

namespace WebUiServiceClient.Client
{
    public class ClientServiceClient : IClientServicClient
    {
        private HttpServices httpServices = new HttpServices();

        public async Task<ClientDetailsResponse> GetDetailsClientById(long id)
        {
            string uri = "api/client/GetDetailsClientById/" + id;

            var clientInDb = await httpServices.Get<ClientDetailsResponse>(uri);

            if (clientInDb == null)
            {
                throw new Exception("Not found Clients");
            }

            return clientInDb;
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

        public async Task<ClientDto> GetClientById(long id)
        {
            string uri = "api/client/getclientbyid/";

            var clientInDb = await httpServices.Get<ClientDto>(uri + id);

            if (clientInDb == null)
            {
                throw new Exception("Not founded");
            }

            return clientInDb;
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

        public async Task<bool> EditClient(long id, string website, long teamId, string clientName)
        {
            string uri = "api/client/editclient";

            var request = new ClientRequest
            {
                Id = id,
                Website = website,
                TeamId = teamId,
                ClientName = clientName
            };

            var editClient = await httpServices.Put(uri, request);

            if (editClient == false)
            {
                throw new Exception("Sikertelen edit");
            }

            return editClient;
        }

        public async Task<bool> DeleteClient(long id)
        {
            string uri = "api/client/deleteclient/";

            var deleteClient = await httpServices.Delete(uri + id);

            if (deleteClient == false)
            {
                throw new Exception("sikertelen törlés");
            }

            return deleteClient;
        }

        public async Task<List<ClientDto>> GetAllClientByUser(string email)
        {
            string uri = "api/client/GetAllClientByUser";

            var request = new ClientRequest
            {
                Email = email
            };

            var clientsInDbByUser = await httpServices.Post<List<ClientDto>, ClientRequest>(uri, request);

            if (clientsInDbByUser == null)
            {
                throw new Exception("Not found");
            }

            return clientsInDbByUser;
        }
    }
}