namespace Server.Infrastructure.Dto.Responses
{
    public class TeamDetailsResponseDto 
    {
        public string PublicPrice { get; set; }

        public string PrivatePrice { get; set; }

        public string Currency { get; set; }

        public long CurrencyId { get; set; }    

        public string UserName { get; set; }

        public long UserID { get; set; }

        public string TeamName { get; set; }

        public long TeamId { get; set; }    

        public long Id { get; set; }

    }
}