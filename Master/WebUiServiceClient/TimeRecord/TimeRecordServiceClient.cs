using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Infrastructure.Dto;
using Server.Infrastructure.Dto.Requests.TimeRecord;
using WebUiServiceClient.Common;

namespace WebUiServiceClient.TimeRecord
{
    public class TimeRecordServiceClient : ITimeRecordServiceClient
    {
        HttpServices httpServices= new HttpServices();
   
        public async Task<TimeRecordDto> AddTimeRecord(long id, string comment, int timeInSec, long todoId)
        {
            string uri = "api/timerecord/addtimerecord";

            var request = new TimeRecordRequest
            {
                Comment = comment,
                TimeInSeconds = timeInSec,
                TodoId = todoId
            };

            var timeRecord = await httpServices.Post<TimeRecordDto, TimeRecordRequest>(uri, request);

            if (timeRecord == null)
            {
                throw new Exception("Sikertelen mentés");
            }

            return timeRecord;
        }

        public async Task<bool> DeleteTimerecord(long id)
        {
            string uri = "api/timerecord/DeleteTimeRecord/";

            var deleteTimeRecord = await httpServices.Delete(uri + id);

            if (deleteTimeRecord == false)
            {
                throw new Exception("Sikertelen törlés");
            }

            return deleteTimeRecord;
        }

        public async Task<bool> EditTimeRecord(long id, string comment, int timeInSec, long todoId)
        {
            string uri = "api/timerecord/edittimerecord/";

            var request = new TimeRecordRequest
            {
                Id = id,
                Comment = comment,
                TimeInSeconds = timeInSec,
                TodoId = todoId
            };

            var editTimeRecord = await httpServices.Put(uri, request);

            if (editTimeRecord == false)
            {
                throw new Exception("Sikertelen módosítás");
            }

            return editTimeRecord;
        }

        public async Task<List<TimeRecordDto>> GetAllTimeRecords()
        {
            string uri = "api/timerecord/getalltimerecords/";

            var timeRecordList = await httpServices.Get<List<TimeRecordDto>>(uri);

            if (timeRecordList == null)
            {
                throw new Exception("Sikertelen lekérdezés");
            }

            return timeRecordList;
        }

        public async Task<TimeRecordDto> GeTimeRecordById(long id)
        {
            string uri = "api/timerecord/GeTimeRecordById/";

            var timeRecordInDb = await httpServices.Get<TimeRecordDto>(uri + id);

            if (timeRecordInDb == null)
            {
                throw new Exception("Sikertelen lekérdezés");
            }

            return timeRecordInDb;
        }

        public async Task<TimeRecordDto> GetTimeRecordByTodoId(long id)
        {
            string uri = "api/timerecord/gettimerecordbytodoid/";

            var timeRecord = await httpServices.Get<TimeRecordDto>(uri + id);

            if (timeRecord == null)
            {
                throw new Exception("Sikertelen lekérdezés");
            }

            return timeRecord;
        }
    }
}