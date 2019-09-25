using System;
using Server.Infrastructure.Dto;
using Server.Infrastructure.Dto.Requests.Team;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace BusinessLogicLayer.Team
{
    using DataAccessLayer;
    using Server.Infrastructure.Dto.Responses;

    public class TeamLogic
    {
        public List<TeamDto> GetTeamListForUser(TeamRequest request)
        {
            List<TeamDto> teamListforUser = new List<TeamDto>();

            using (var db = new TimeTrackerModelContainer())
            {
                var user = db.User.First(x => x.Email == request.Name);

                var TeamList = from t in db.Team
                    join u in db.UserTeamLink on t.Id equals u.TeamId
                    where u.UserID == user.Id
                    select t;

                foreach (var tempValue in TeamList)
                {
                    teamListforUser.Add(new TeamDto { Id = tempValue.Id, Name = tempValue.Name });
                }

                return teamListforUser;
            }
        }

        public List<TeamDto> GetTeamList()
        {
            using (var db = new TimeTrackerModelContainer())
            {
                var TeamList = db.Team.AsEnumerable().Select(x => new TeamDto { Id = x.Id, Name = x.Name }).ToList();

                return TeamList;
            }
        }

        public Team GetTeamById(int id)
        {
            Team team;

            using (var db = new TimeTrackerModelContainer())
            {
                var result = db.Team.Where(x => x.Id == id).First();
                return result;
            }
        }

        public Team AddNewTeam(TeamRequest request)
        {
            using (var db = new TimeTrackerModelContainer())
            {
                var team = new Team();
                team.Name = request.Name;
                var user = db.User.First(x => x.Email == request.UserEmail);

                db.Team.Add(team);

                var userTeamLink = new UserTeamLink
                {
                    PublicPrice = request.PublicPrice,
                    PrivatePrice = request.PrivatePrice,
                    CurrencyId = request.CurrencyId,
                    UserID = user.Id,
                    TeamId = team.Id
                };

                db.UserTeamLink.Add(userTeamLink);

                db.SaveChanges();

                return team;
            }
        }

        public Team EditTeam(TeamRequest request)
        {
            var newTeam = new Team();
     
            using (var db = new TimeTrackerModelContainer())
            {
                var result = db.Team.First(x => x.Id == request.Id);

                newTeam.Id = result.Id;
                newTeam.Name = request.Name;

                var s = db.Set<Team>().Local.FirstOrDefault(x => x.Id == request.Id);

                if (s != null)
                {
                    db.Entry(s).State = EntityState.Detached;
                }

                if (result.Id == request.Id)
                {

                    db.Entry(newTeam).State = EntityState.Modified;

                    db.SaveChanges();
                }
            }
            return newTeam;
        }

        public Team DeleteTeamAndUserLink(TeamRequest request)
        {
            Team newTeam = new Team();
 
            using (var db = new TimeTrackerModelContainer())
            {
                var userTeamLink = db.UserTeamLink.First(x => x.TeamId == request.Id);
                newTeam= db.Team.First(x => x.Id == request.Id);

                db.UserTeamLink.Remove(userTeamLink);
                db.Team.Remove(newTeam);

                db.SaveChanges();
            }

            return newTeam;
        }

        public bool DeleteTeam(long id)
        {
            using (var db = new TimeTrackerModelContainer())
            {
                var team = db.Team.FirstOrDefault(x => x.Id == id);
                db.Team.Remove(team);

                return true;
            }
        }

        public List<TeamDetailsResponseDto> GetTeamDetails(long id)
        {
            List<TeamDetailsResponseDto> teamDetails = new List<TeamDetailsResponseDto>();

            using (var db = new TimeTrackerModelContainer())
            {
                var result = db.UserTeamLink.AsEnumerable().Where(x => x.TeamId == id);
  
                foreach (var list in result)
                {
                    teamDetails.Add(new TeamDetailsResponseDto
                    {
                        Id = list.Id,
                        UserName = list.User.Name,
                        UserID = list.UserID,
                        TeamName = list.Team.Name,
                        Currency = list.Currency.Code,
                        PublicPrice = list.PublicPrice,
                        PrivatePrice = list.PrivatePrice,
                        TeamId = list.Team.Id
                    });
                }        
            }
            
            return teamDetails;
        }

        public TeamDetailsResponseDto GetTeamDetailsForEdit(long id)
        {
            var resultTeam = new TeamDetailsResponseDto();

            using (var db = new TimeTrackerModelContainer())
            {
                var result = db.UserTeamLink.First(x => x.Id == id);
              
                resultTeam.Id = result.Id;
                resultTeam.PublicPrice = result.PublicPrice;
                resultTeam.PrivatePrice = result.PrivatePrice;
                resultTeam.Currency = result.Currency.Code;
                resultTeam.TeamName = result.Team.Name;
                resultTeam.UserName = result.User.Name;
                resultTeam.TeamId = result.TeamId;
            }

            return resultTeam;
        }

        public bool EditTeamDetails(TeamDetailsResponseDto request)
        {
            bool flag = false;
            Team editTeam=new Team
            {
                Id = request.TeamId,
                Name = request.TeamName
            };

            using (var db = new TimeTrackerModelContainer())
            {
                var userTeamLink = db.UserTeamLink.First(x => x.Id == request.Id);
                userTeamLink.CurrencyId = request.CurrencyId;
                userTeamLink.TeamId = userTeamLink.TeamId;
                userTeamLink.PrivatePrice = request.PrivatePrice;
                userTeamLink.PublicPrice = request.PublicPrice;

                editTeam.Id = userTeamLink.TeamId;

                db.Entry(editTeam).State = EntityState.Modified;
                db.Entry(userTeamLink).State = EntityState.Modified;
                db.SaveChanges();
                flag = true;
            }

            return flag;
        }

        public User AddnewUserToTeam(AddNewUserToTeamRequest request)
        {
            User user = new User();

            var userTeamLink = new UserTeamLink
            {
                PublicPrice = request.PublicPrice,
                PrivatePrice = request.PrivatePrice,
                CurrencyId = request.CurrencyId,
                UserID = request.UserID,
                TeamId = request.TeamId,
                Id = request.Id
            };

            using (var db = new TimeTrackerModelContainer())
            { 
                db.UserTeamLink.Add(userTeamLink);
                db.SaveChanges();

                user.Id = userTeamLink.UserID;
            }

            return user;
        }
    }
}
