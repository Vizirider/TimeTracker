using DataAccessLayer;
using Server.Infrastructure.Dto.Responses;

namespace Server.Infrastructure.Mapper
{
    public static class TeamDetailsMappers
    {
        public static TeamDetailsResponseDto Map(this UserTeamLink source)
        {
            var target = new TeamDetailsResponseDto
            {
                PrivatePrice = source.PrivatePrice,
                PublicPrice = source.PublicPrice,
                Currency = source.Currency.Code,
                UserName = source.User.Name,
                TeamName = source.Team.Name,
                Id = source.Id
            };

            return target;
        }
    }
}