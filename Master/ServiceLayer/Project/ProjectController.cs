using BusinessLogicLayer.Project;
using Server.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Web.Http;
using Server.Infrastructure.Dto.Requests.Project;
using Server.Infrastructure.Dto.Responses;
using Server.Infrastructure.Mapper;

namespace ServiceLayer.Controllers.Project
{
    public class ProjectController : ApiController
    {
        private static readonly ProjectLogic _projectLogic = new ProjectLogic();

        [HttpGet]
        public List<ProjectDetailsResponse> GetAllProjectByTeamId(long id)
        {
            try
            {
                return _projectLogic.GetAllProjectByTeamId(id);
            }
            catch (Exception e)
            {
                throw new FaultException("Sikertelen bejelentkezés.");
            }
        }

        [HttpGet]
        public ProjectDetailsResponse GetDetailsProjectById(long id)
        {
            try
            {
                return _projectLogic.GetDetailsProjectById(id);
            }
            catch (Exception e)
            {
                throw new FaultException("not found");
            }
        }

        [HttpPost]
        public ProjectDto AddNewProject(ProjectRequest request)
        {
            try
            {
                return _projectLogic.AddnewProject(request).Map();
            }
            catch (Exception e)
            {
                throw new FaultException("Sikertelen project hozzáadás !");
            }
        }

        [HttpGet]
        public ProjectDto GetProjectById(long id)
        {
            try
            {
                return _projectLogic.GetProjectById(id).Map();
            }
            catch (Exception e)
            {
                throw new FaultException("Project not found!");
            }
        }

        [HttpPut]
        public bool EditProject(ProjectRequest request)
        {
            try
            {
                return _projectLogic.EditProject(request.Id, request.Name, request.DeadLine, request.EffortInHours,
                    request.EffortInCurrency, request.CurrencyId, request.TeamId, request.StatusId, request.ClientId);
            }
            catch (Exception e)
            {
                throw new FaultException("Not successful change");
            }
        }

        [HttpGet]
        public List<ProjectDto> GetAllProject()
        {
            try
            {
                return _projectLogic.GetAllProject();
            }
            catch (Exception e)
            {
                throw new FaultException("Not found!");
            }
        }

        [HttpDelete]
        public bool DeleteProject(long id)
        {
            try
            {
                return _projectLogic.DeleteProject(id);
            }
            catch (Exception e)
            {
                throw new FaultException("sikertelen törlés");
            }
        }

        [HttpPost]
        public List<ProjectDto> GetAllProjectByUser(ProjectRequest request)
        {
            try
            {
                return _projectLogic.GetAllProjectByUser(request.UserEmail);
            }
            catch (Exception e)
            {
                throw new FaultException("Not found");
            }
        }

        [HttpPost]
        public List<ProjectDto> GetAllProjectByClient(ProjectRequest request)
        {
            try
            {
                return _projectLogic.GetAllProjectByClient(request.UserEmail);
            }
            catch (Exception e)
            {
                throw new FaultException("Not found");
            }
        }
    }
}
