using DataAccessLayer;

namespace Server.Infrastructure.Dto.Requests.Team
{
    public class TeamRequest : UserTeamLink
    {
        public string Name { get; set; }

        public long Id { get; set; }

        public string UserEmail { get; set; }
    }
}
