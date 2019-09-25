using BusinessLogicLayer.Status;
using Server.Infrastructure.Dto;
using Server.Infrastructure.Dto.Requests.Status;
using Server.Infrastructure.Mapper;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Web.Http;

namespace ServiceLayer.Controllers.Status
{
    public class StatusController : ApiController
    {
        private static readonly StatusLogic _StatusLogic = new StatusLogic();

        [HttpGet]
        public List<StatusDto> GetAllStatus()
        {
            try
            {
                return _StatusLogic.GetAllStatus();
            }
            catch (Exception e)
            {
                throw new FaultException("Sikertelen Status lekérdezés !");
            }
        }

        [HttpPost]
        public StatusDto AddNewStatus(StatusRequest request)
        {
            try
            {
                return _StatusLogic.AddStatus(request).Map();
            }
            catch (Exception e)
            {
                throw new FaultException("Sikertelen mentés");
            }
        }

        [HttpPut]
        public StatusDto EditStatus(StatusRequest request)
        {
            try
            {
                return _StatusLogic.EditStatus(request).Map();
            }
            catch (Exception e)
            {
                throw new FaultException("Sikertelen mentés");
            }
        }

        [HttpGet]
        public StatusDto GetStatusById(long id)
        {
            try
            {
                return _StatusLogic.GetStatusById(id).Map();
            }
            catch (Exception e)
            {
                throw new FaultException("Not found!");
            }
        }

        [HttpDelete]
        public bool DeleteStatus(long id)
        {
            try
            {
                return _StatusLogic.DeleteStatus(id);
            }
            catch (Exception e)
            {
                throw new FaultException("Sikertelen törlés!");
            }
        }


    }
}
