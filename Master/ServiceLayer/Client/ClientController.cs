using BusinessLogicLayer.Client;
using Server.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Server.Infrastructure.Dto.Requests.Client;
using Server.Infrastructure.Dto.Responses;
using Server.Infrastructure.Mapper;

namespace ServiceLayer.Client
{
    using System.ServiceModel;

    public class ClientController : ApiController
    {
        private static readonly ClientLogic _clientLogic = new ClientLogic();

        [HttpGet]
        public List<ClientDto> GetAllClient()
        {
            try
            {
                return _clientLogic.GetAllClient();
            }
            catch (Exception e)
            {
                throw new FaultException("Sikertelen client lekérdezés.");
            }
        }

        [HttpGet]
        public ClientDetailsResponse GetDetailsClientById(long id)
        {
            try
            {
                return _clientLogic.GetClientDetailsById(id);
            }
            catch (Exception e)
            {
                throw new FaultException("Sikertelen lekérdezés!");
            }
        }

        [HttpGet]
        public ClientDto GetClientById(long id)
        {
            try
            {
                return _clientLogic.GetClientById(id).Map();
            }
            catch (Exception e)
            {
                throw new FaultException("Not found Client");
            }
        }

        [HttpPut]
        public bool EditClient(ClientRequest request)
        {
            try
            {
                return _clientLogic.EditClient(request.Id, request.Website, request.TeamId, request.ClientName);
            }
            catch (Exception e)
            {
                throw new FaultException("sikertelen módosítás");
            }
        }

        [HttpDelete]
        public bool DeleteClient(long id)
        {
            try
            {
                return _clientLogic.DeleteClient(id);
            }
            catch (Exception e)
            {
                throw new FaultException("Sikertelen törlés");
            }
        }

        [HttpPost]
        public List<ClientDto> GetAllClientByUser(ClientRequest request)
        {
            try
            {
                return _clientLogic.GetAllClientByUser(request.Email);
            }
            catch (Exception e)
            {
                throw new FaultException("Not found");
            }
        }
    }
}
