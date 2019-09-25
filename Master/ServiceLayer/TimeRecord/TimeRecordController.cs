using BusinessLogicLayer.TimeRecord;
using Server.Infrastructure.Dto;
using Server.Infrastructure.Dto.Requests.TimeRecord;
using Server.Infrastructure.Mapper;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Web.Http;

namespace ServiceLayer.TimeRecord
{
    public class TimeRecordController : ApiController
    {
        private static readonly TimeRecordLogic _timeRecordLogic = new TimeRecordLogic();

        [HttpPost]
        public TimeRecordDto AddTimeRecord(TimeRecordRequest request)
        {
            try
            {
                return _timeRecordLogic
                    .AddTimeRecord(request.Id, request.Comment, request.TimeInSeconds, request.TodoId)
                    .Map();
            }
            catch (Exception e)
            {
                throw new FaultException("Sikertelen művelet");
            }
        }


        [HttpGet]
        public List<TimeRecordDto> GetAllTimeRecords()
        {
            try
            {
                return _timeRecordLogic.GetAllTimeRecords();
            }
            catch (Exception e)
            {
                throw new FaultException("Sikertelen művelet");
            }
        }

        [HttpGet]
        public TimeRecordDto GetTimeRecordByTodoId(long id)
        {
            try
            {
                return _timeRecordLogic.GetTimeRecordByTodoId(id).Map();
            }
            catch (Exception e)
            {
                throw new FaultException("Sikertelen művelet");
            }
        }

        [HttpPut]
        public bool EditTimeRecord(TimeRecordRequest request)
        {
            try
            {
                return _timeRecordLogic.EditTimeRecord(request.Id, request.Comment, request.TimeInSeconds,
                    request.TodoId);
            }
            catch (Exception e)
            {
                throw new FaultException("Sikertelen update");
            }
        }

        [HttpDelete]
        public bool DeleteTimeRecord(long id)
        {
            try
            {
                return _timeRecordLogic.DeleteTimeRecord(id);
            }
            catch (Exception e)
            {
                throw new FaultException("Sikertelen törlés");
            }
        }

        [HttpGet]
        public TimeRecordDto GeTimeRecordById(long id)
        {
            try
            {
                return _timeRecordLogic.GeTimeRecordById(id).Map();
            }
            catch (Exception e)
            {
                throw new FaultException("Sikertelen lekérdezés");
            }
        }
    }
}
