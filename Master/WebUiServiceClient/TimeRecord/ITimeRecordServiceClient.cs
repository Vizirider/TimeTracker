using System.Collections.Generic;
using Server.Infrastructure.Dto;
using System.Threading.Tasks;
using System.Web.Mvc.Routing.Constraints;

namespace WebUiServiceClient.TimeRecord
{
    public interface ITimeRecordServiceClient
    {
        Task<TimeRecordDto> AddTimeRecord(long id, string comment, int timeInSec, long todoId);

        Task<List<TimeRecordDto>> GetAllTimeRecords();

        Task<TimeRecordDto> GetTimeRecordByTodoId(long id);

        Task<bool> EditTimeRecord(long id, string comment, int timeInSec, long todoId);

        Task<bool> DeleteTimerecord(long id);

        Task<TimeRecordDto> GeTimeRecordById(long id);
    }
}