using Server.Infrastructure.Dto;
using Server.Infrastructure.Dto.Requests.Project;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BusinessLogicLayer.Status;
using Server.Infrastructure.Enums;

namespace BusinessLogicLayer.Project
{
    using DataAccessLayer;
    using Server.Infrastructure.Dto.Responses;

    public class ProjectLogic
    {
        public List<ProjectDto> GetAllProjectByUser(string email)
        {
            List<ProjectDto> projectList = new List<ProjectDto>();

            using (var db = new TimeTrackerModelContainer())
            {
                var user = db.User.First(x => x.Email == email);

                var teamsId = from t in db.UserTeamLink where t.UserID == user.Id select t.TeamId;
                var projectLis = from p in db.Project where teamsId.Contains(p.TeamId) select p;

                foreach (var temp in projectLis)
                {
                    projectList.Add(new ProjectDto
                    {
                        Id = temp.Id,
                        Name = temp.Name
                    });
                }
            }

            return projectList;
        }

        public List<ProjectDetailsResponse> GetAllProjectByTeamId(long id)
        {
            var list = new List<ProjectDetailsResponse>();

            using (var db = new TimeTrackerModelContainer())
            {
                var result = db.Project.AsEnumerable().Where(x => x.TeamId == id);
              
                foreach (var tempList in result)
                {
                    list.Add(new ProjectDetailsResponse
                    {
                        Id = tempList.Id,
                        ProjectName = tempList.Name,
                        DeadLine = tempList.DeadLine,
                        EffortInHours = tempList.EffortInHours,
                        EffortInCurrency = tempList.EffortInCurrency,
                        TeamName = tempList.Team.Name,
                        StatusName = tempList.Status.Name,
                        Clientname = tempList.Client.Website,
                        Currency = db.Currency.First(x=>x.Id == tempList.CurrencyId).Code
                    });
                }
            }

            return list;
        }
        
        public ProjectDetailsResponse GetDetailsProjectById(long id)
        {
            var detailsProject = new ProjectDetailsResponse();

            using (var db = new TimeTrackerModelContainer())
            {
                var result = db.Project.FirstOrDefault(x => x.Id == id);

                detailsProject.Id = result.Id;
                detailsProject.ProjectName = result.Name;
                detailsProject.DeadLine = result.DeadLine;
                detailsProject.EffortInHours = result.EffortInHours;
                detailsProject.EffortInCurrency = result.EffortInCurrency;
                detailsProject.TeamName = result.Team.Name;
                detailsProject.StatusName = result.Status.Name;
                detailsProject.Clientname = result.Client.User.Name;
                detailsProject.TeamId = result.TeamId;
                detailsProject.ClientId = result.ClientId;
                detailsProject.Currency = db.Currency.First(x => x.Id == result.CurrencyId).Code;
            }

            return detailsProject;
        }


        public Project AddnewProject(ProjectRequest request)
        {
            var status = new StatusLogic();

            Project newProject = new Project
            {
                Name = request.Name,
                DeadLine = request.DeadLine,
                EffortInHours = request.EffortInHours,
                EffortInCurrency = request.EffortInCurrency,
                TeamId = request.TeamId,
                StatusId = status.GetStatus(States.New).Id,
                ClientId = request.ClientId,
                Id = request.Id,
                CurrencyId = request.CurrencyId
            };

            using (var db = new TimeTrackerModelContainer())
            {
                db.Project.Add(newProject);
                db.SaveChanges();
            }

            return newProject;
        }

        public Project GetProjectById(long id)
        {
            var project = new Project();

            using (var db = new TimeTrackerModelContainer())
            {
                 project = db.Project.First(x => x.Id == id); 
            }

            return project;
        }

        public bool EditProject(long id, string projectName, DateTime? deadLine, Nullable<short> effortInHours,
            Nullable<decimal> effortInCurrency, long currencyId, long teamId, long statusId,long clientId)
        {
            bool flag = false;
            var newProject = new Project
            {
                Id = id,
                Name = projectName,
                DeadLine = deadLine,
                EffortInHours = effortInHours,
                EffortInCurrency = effortInCurrency,
                TeamId = teamId,
                StatusId = statusId,
                ClientId = clientId,
                CurrencyId = currencyId
            };

            using (var db = new TimeTrackerModelContainer())
            {
                db.Entry(newProject).State = EntityState.Modified;
                db.SaveChanges();
                flag = true;
            }
            return flag;
        }

        public List<ProjectDto> GetAllProject()
        {
            List<ProjectDto> list = new List<ProjectDto>();

            using (var db = new TimeTrackerModelContainer())
            {
                var result = db.Project.AsEnumerable().ToList();

                foreach (var temp in result)
                {
                    list.Add( new ProjectDto
                    {
                        Id = temp.Id,
                        Name = temp.Name,
                        DeadLine = temp.DeadLine,
                        EffortInHours = temp.EffortInHours,
                        EffortInCurrency = temp.EffortInCurrency,
                        TeamId = temp.TeamId,
                        StatusId = temp.StatusId,
                        ClientId = temp.ClientId
                    });
                }
            }

            return list;
        }

        public bool DeleteProject(long id)
        {
            bool flag = false;
            
            using (var db = new TimeTrackerModelContainer())
            {
                var result = db.Project.First(x => x.Id == id);

                db.Project.Remove(result);
                db.SaveChanges();
                flag = true;
            }

            return flag;
        }

        public List<ProjectDto> GetAllProjectByClient(string email)
        {
            var projectList = new List<ProjectDto>();

            using (var db = new TimeTrackerModelContainer())
            {
                var clientId = db.Client.First(x => x.User.Email == email);
                var list = db.Project.AsEnumerable().Where(x => x.ClientId == clientId.Id);

                foreach (var tempList in list)
                {
                    projectList.Add(new ProjectDto
                    {
                        Id = tempList.Id,
                        Name = tempList.Name
                    });
                }
            }

            return projectList;
        }
    }
}
