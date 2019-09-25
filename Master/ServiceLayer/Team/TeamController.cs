using BusinessLogicLayer.Team;
using Server.Infrastructure.Dto;
using Server.Infrastructure.Dto.Responses;
using Server.Infrastructure.Mapper;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ServiceLayer.Team
{
    using Server.Infrastructure.Dto.Requests.Team;
    using System.ServiceModel;

    public class TeamController : ApiController
    {
        private static readonly TeamLogic _teamLogic = new TeamLogic();

        [HttpGet]
        public List<TeamDto> GetAllTeam()
        {
            try
            {
                return _teamLogic.GetTeamList();
            }
            catch (Exception e)
            {
                throw new FaultException("Váratlan hiba történt a TeamDto lekérdezése során.");
            }
        }

        [HttpGet]
        public TeamDto GetTeamById(int id)
        {
            try
            {
                return _teamLogic.GetTeamById(id).Map();
            }
            catch (Exception e)
            {
                throw new FaultException("nincs ilyen csapat!");
            }
        }

        [HttpPost]
        public List<TeamDto> GetTeamsToUser(TeamRequest user)
        {
            try
            {
                return _teamLogic.GetTeamListForUser(user);
            }
            catch (Exception e)
            {
                throw new FaultException("Váratlan hiba történt a TeamDto lekérdezése során.");
            }
        }

        [HttpPost]
        public TeamDto AddNewTeam(TeamRequest team)
        {
            try
            {
                return _teamLogic.AddNewTeam(team).Map();
            }
            catch (Exception e)
            {
                throw new FaultException("Sikertelen csapat mentés!");
            }
        }
        [HttpPost]
        public TeamDto EditTeam(TeamRequest request)
        {
            try
            {
                return _teamLogic.EditTeam(request).Map();
            }
            catch (Exception e)
            {
                throw new FaultException("Sikertelen csapat módosítás!");
            }
        }

        [HttpPost]
        public TeamDto DeleteTeamAndUserLink(TeamRequest request)
        {
            try
            {
                return _teamLogic.DeleteTeamAndUserLink(request).Map();
            }
            catch (Exception e)
            {
                throw new FaultException("Sikertelen csapat törlés");
            }
        }

        [HttpDelete]
        public bool DeleteTeam(long id)
        {
            try
            {
                return _teamLogic.DeleteTeam(id);
            }
            catch (Exception e)
            {
                throw new FaultException("Sikertelen törlés");
            }
        }

        [HttpGet]
        public List<TeamDetailsResponseDto> GetTeamDetails(long id )
        {
            try
            {
                return _teamLogic.GetTeamDetails(id);
            }
            catch (Exception e)
            {
                throw new FaultException("Sikertelen lekérdezés!");
            }
        }

        [HttpPost]
        public UserDto AddNewUserToTeam(AddNewUserToTeamRequest request)
        {
            try
            {
                return _teamLogic.AddnewUserToTeam(request).Map();
            }
            catch (Exception e)
            {
                throw new FaultException("Sikertelen lekérdezés!");
            }
        }

        [HttpPut]
        public bool EditTeamDetails(TeamDetailsResponseDto request)
        {
            try
            {
                return _teamLogic.EditTeamDetails(request);
            }
            catch (Exception e)
            {
                throw new FaultException("Sikertelen...");
            }
        }

        [HttpGet]
        public TeamDetailsResponseDto GetTeamDetailsForEdit(long id)
        {
            try
            {
                return _teamLogic.GetTeamDetailsForEdit(id);
            }
            catch (Exception e)
            {
                throw new FaultException("Not found");
            }
        }
    }
}

