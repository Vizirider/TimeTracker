namespace Server.Infrastructure.Dto.Requests.Team
{
    public class AddNewUserToTeamRequest
    {
        public string PublicPrice { get; set; }

        public string PrivatePrice { get; set; }

        public long CurrencyId { get; set; }

        public long UserID { get; set; }

        public long TeamId { get; set; }

        public long Id { get; set; }
    }
}