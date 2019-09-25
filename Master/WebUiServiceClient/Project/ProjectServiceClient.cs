using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Threading.Tasks;
using Server.Infrastructure.Dto;
using Server.Infrastructure.Dto.Requests.Project;
using Server.Infrastructure.Dto.Responses;
using WebUiServiceClient.Common;

namespace WebUiServiceClient.Project
{
    public class ProjectServiceClient : IProjectServiceClient
    {
        HttpServices httpServices=new HttpServices();

        public async Task<List<ProjectDetailsResponse>> GetAllProjectByTeamId(long teamId)
        {
            string uri = "api/project/GetAllProjectByTeamId/" + teamId;

            var projectInDb = await httpServices.Get<List<ProjectDetailsResponse>>(uri);

            if (projectInDb == null)
            {
                throw new Exception("Not found project!");
            }

            return projectInDb;
        }

        public async Task<List<ProjectDto>> GetAllProject()
        {
            string uri = "api/project/GetAllProject";

     
            var projectInDb = await httpServices.Get<List<ProjectDto>>(uri);

            if (projectInDb == null)
            {
                throw new Exception("Sikertelen lekérdezés!");
            }

            return projectInDb;
        }

        public async Task<ProjectDto> AddnewProject(string name, DateTime? deadline, Nullable<short> effortInHours, Nullable<decimal> effortInCurrency, long currencyId, long TeamId, long clientId)
        {
            string uri = "api/project/AddNewProject";

            var request = new ProjectRequest
            {
                Name = name,
                DeadLine = deadline,
                EffortInHours = effortInHours,
                EffortInCurrency = effortInCurrency,
                TeamId = TeamId,
                ClientId = clientId,
                CurrencyId = currencyId
            };

            var addNewProjectToDb = await httpServices.Post<ProjectDto, ProjectRequest>(uri, request);

            if (addNewProjectToDb == null)
            {
                throw new Exception("Sikertelen mentés");
            }

            return addNewProjectToDb;
        }

        public async Task<bool> EditProject(long id, string name, DateTime? deadline, short? effortInHours, decimal? effortInCurrency, long currencyId, long TeamId, long statusId, long clientId)
        {
            string uri = "api/project/editproject/";

            var request = new ProjectRequest
            {
                Id = id,
                Name = name,
                DeadLine = deadline,
                EffortInHours = effortInHours,
                EffortInCurrency = effortInCurrency,
                TeamId = TeamId,
                StatusId = statusId,
                ClientId = clientId,
                CurrencyId = currencyId
            };

            var editProjectInDb = await httpServices.Put<ProjectRequest>(uri, request);

            if (editProjectInDb == false)
            {
                throw new Exception("Sikertelen módosítás");
            }

            return true;

        }

        public async Task<bool> DeleteProject(long id)
        {
            string uri = "api/project/deleteproject/";

            var deleteProjectFromDb = await httpServices.Delete(uri + id);
            if (deleteProjectFromDb == false)
            {
                throw new Exception("Sikertelen törlés");
            }

            return true;
        }

        public async Task<ProjectDto> GetProjectById(long id)
        {
            string uri = "api/project/GetProjectById/";

            var projectInDb = await httpServices.Get<ProjectDto>(uri + id);

            if (projectInDb == null)
            {
                throw new Exception("Not found!");
            }

            return projectInDb;
        }

        public async Task<ProjectDetailsResponse> GetDetailsProjectById(long id)
        {
            string uri = "api/project/GetDetailsProjectById/";

            var resultDtailsProject = await httpServices.Get<ProjectDetailsResponse>(uri + id);

            if (resultDtailsProject == null)
            {
                throw new Exception("not found");
            }

            return resultDtailsProject;
        }

        public async Task<List<ProjectDto>> GetAllProjectByUser(string userEmail)
        {
            string uri = "api/project/GetAllProjectByUser";

            var request = new ProjectRequest
                {
                    UserEmail = userEmail
                };

            var projectByUser = await httpServices.Post<List<ProjectDto>, ProjectRequest>(uri, request);

            if (projectByUser == null)
            {
                throw new Exception("Not found");
            }

            return projectByUser;
        }

        public async Task<List<ProjectDto>> GetAllProjectByClient(string clienEmail)
        {
            string uri = "api/project/GetAllProjectByClient/";

            var request = new ProjectRequest
            {
                UserEmail = clienEmail
            };

            var projectInDb = await httpServices.Post<List<ProjectDto>, ProjectRequest>(uri, request);

            if (projectInDb == null)
            {
                throw new Exception("Not found");
            }

            return projectInDb;
        }
    }
}