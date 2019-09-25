namespace Server.Infrastructure.Dto.Requests.TimeRecord
{
    public class TimeRecordRequest
    {
        public long TodoId { get; set; }

        public int TimeInSeconds { get; set; }

        public string Comment { get; set; }

        public long Id { get; set; }
    }
}