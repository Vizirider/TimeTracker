using DataAccessLayer;
using Server.Infrastructure.Dto;

namespace Server.Infrastructure.Mapper
{
    public static class TimeRecordMappers
    {

        public static TimeRecordDto Map(this TimeRecord source)
        {
            var target = new TimeRecordDto
            {
                Id = source.Id,
                Comment = source.Comment,
                TimeInSeconds = source.TimeInSeconds,
                TodoId = source.TodoId
            };

            return target;
        }
    }
}