namespace Server.Infrastructure.Dto.Requests.Team
{
    public class DeleteUserFromTeamRequest
    {
        public long UserId { get; set; }

        public long TeamId { get; set; }
    }
}