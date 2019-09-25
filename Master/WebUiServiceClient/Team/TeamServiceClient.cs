using Server.Infrastructure.Dto;
using Server.Infrastructure.Dto.Requests.Team;
using Server.Infrastructure.Dto.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebUiServiceClient.Common;

namespace WebUiServiceClient.Team
{
    public class TeamServiceClient : ITeamServiceClient
    {
        HttpServices httpServices = new HttpServices();

        public async Task<TeamDto> AddNewTeam(string TeamName, string publicPrice, string privatePrice, long currencyId,
            string userEmail)
        {
            string uri = "api/team/AddNewTeam";

            var request = new TeamRequest
            {
                Name = TeamName,
                PublicPrice = publicPrice,
                PrivatePrice = privatePrice,
                CurrencyId = currencyId,
                UserEmail = userEmail
            };

            var addNewTeamToDb = await httpServices.Post<TeamDto, TeamRequest>(uri, request);

            if (addNewTeamToDb == null)
            {
                throw new Exception("Nincs csapat!");
            }

            return addNewTeamToDb;
        }

        public async Task<UserDto> AddNewUserToTeam(AddNewUserToTeamRequest request)
        {
            string uri = "api/team/AddNewUserToTeam";

            var addUserToTeam = await httpServices.Post<UserDto, AddNewUserToTeamRequest>(uri, request);

            if (addUserToTeam == null)
            {
                throw new Exception("Nem sikerült a mentés!");
            }

            return addUserToTeam;
        }

        public async Task<bool> DeleteTeam(long id)
        {
            string uri = "api/team/DeleteTeam/";

            var deleteTeam = await httpServices.Delete(uri + id);

            if (deleteTeam == false)
            {
                throw new Exception("Sikertelen törlés");
            }

            return deleteTeam;
        }

        public async Task<TeamDto> DeleteTeamAndUserLink(long id)
        {
            string uri = "api/Team/DeleteTeamAndUserLink/";

            var request = new TeamRequest
            {
                Id = id
            };

            var deleteFromDb = await httpServices.Post<TeamDto, TeamRequest>(uri, request);

            if (deleteFromDb == null)
            {
                throw new Exception("Sikertelen törlés!");
            }

            return deleteFromDb;
        }

        public async Task<TeamDto> EditTeam(long id, string name)
        {
            string uri = "api/Team/EditTeam/";

            var request = new TeamRequest
            {
                Id = id,
                Name = name
            };

            var teamInDb = await httpServices.Post<TeamDto, TeamRequest>(uri, request);

            if (teamInDb == null)
            {
                throw new Exception("Sikertelen csapat módosítás!");
            }

            return teamInDb;
        }

        public async Task<bool> EditTeamDetails(long id, string TeamName, string publicPrice, string privatePrice, long currencyId)
        {
            string uri = "api/team/editteamdetails/";

            var request = new TeamDetailsResponseDto
            {
                Id = id,
                TeamName = TeamName,
                PublicPrice = publicPrice,
                PrivatePrice = privatePrice,
                CurrencyId = currencyId,
                
            };

            var editDetailsTeam = await httpServices.Put(uri, request);

            if (editDetailsTeam == false)
            {
                throw new Exception("Sikertelen");
            }

            return editDetailsTeam;
        }

        public async Task<List<CurrencyDto>> GetAllCurrency()
        {
            string uri = "api/currency/getallcurrency/";

            var currencyInDb = await httpServices.Get<List<CurrencyDto>>(uri);

            if (currencyInDb == null)
            {
                throw new Exception("Nincs csapat!");
            }

            return currencyInDb;
        }

        public async Task<List<TeamDto>> GetAllTeam()
        {
            string uri = "api/Team/GetAllTeam/";

            var teamInDb = await httpServices.Get<List<TeamDto>>(uri);

            if (teamInDb == null)
            {
                throw new Exception("Nincs csapat!");
            }

            return teamInDb;
        }

        public async Task<TeamDto> GetTeamById(long id)
        {
            string uri = "api/Team/GetTeamById/" + id;

            var teamInDb = await httpServices.Get<TeamDto>(uri);

            if (teamInDb == null)
            {
                throw new Exception("Nincs ilyen csapat!");
            }

            return teamInDb;
        }

        public async Task<List<TeamDetailsResponseDto>> GetTeamDetails(long id)
        {
            string uri = "api/team/GetTeamDetails/" + id;

            var teamDetailsInDB = await httpServices.Get<List<TeamDetailsResponseDto>>(uri);

            if (teamDetailsInDB == null)
            {
                throw new Exception("Sikertelen lekérdezés!");
            }

            return teamDetailsInDB;
        }

        public async Task<TeamDetailsResponseDto> GetTeamDetailsForEdit(long id)
        {
            string uri = "api/team/GetTeamDetailsForEdit/";

            var detailsTeamInDb = await httpServices.Get<TeamDetailsResponseDto>(uri + id);

            if (detailsTeamInDb == null)
            {
                throw new Exception("Not found");
            }

            return detailsTeamInDb;
        }

        public async Task<List<TeamDto>> GetTeamsToUser(string email)
        {
            string uri = "api/team/GetTeamsToUser";

            var request = new TeamDto
            {
                Name = email
            };

            var teamsInDb = await httpServices.Post<List<TeamDto>, TeamDto>(uri, request);

            if (teamsInDb == null)
            {
                throw new Exception("Nincs csapat!");
            }

            return teamsInDb;
        }
    }
}