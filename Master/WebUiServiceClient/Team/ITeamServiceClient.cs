using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Infrastructure.Dto;
using Server.Infrastructure.Dto.Requests.Team;
using Server.Infrastructure.Dto.Responses;

namespace WebUiServiceClient.Team
{
    public interface ITeamServiceClient
    {
        Task<TeamDto> GetTeamById(long id);

        Task<List<TeamDto>> GetAllTeam();

        Task<List<TeamDto>> GetTeamsToUser(string email);

        Task<TeamDto> AddNewTeam(string TeamName, string publicPrice, string privatePrice, long currencyId, string userEmail);

        Task<TeamDto> EditTeam(long id, string name);

        Task<TeamDto> DeleteTeamAndUserLink(long id);

        Task<bool> DeleteTeam(long id);

        Task<List<TeamDetailsResponseDto>> GetTeamDetails(long id);

        Task<List<CurrencyDto>> GetAllCurrency();

        Task<UserDto> AddNewUserToTeam(AddNewUserToTeamRequest request);

        Task<bool> EditTeamDetails(long id, string TeamName, string publicPrice, string privatePrice, long currencyId);

        Task<TeamDetailsResponseDto> GetTeamDetailsForEdit(long id);
    }
}