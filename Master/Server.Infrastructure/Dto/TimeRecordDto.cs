namespace Server.Infrastructure.Dto
{
    public class TimeRecordDto : EntityBaseDto
    {
        public long TodoId { get; set; }

        public string TodoTitle  { get; set; }

        public int TimeInSeconds { get; set; }

        public string Comment { get; set; }

        public long Id { get; set; }
    }
}