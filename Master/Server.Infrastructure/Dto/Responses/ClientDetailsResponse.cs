namespace Server.Infrastructure.Dto.Responses
{
    public class ClientDetailsResponse
    {
        public long Id { get; set; }

        public string ClientName  { get; set; }

        public string Website { get; set; }

        public string TeamName { get; set; }

        public string ProjectName { get; set; }

        public long TeamId { get; set; }    
    }
}