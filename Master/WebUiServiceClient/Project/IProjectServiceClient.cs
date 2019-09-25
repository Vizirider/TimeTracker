using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Infrastructure.Dto;
using Server.Infrastructure.Dto.Responses;

namespace WebUiServiceClient.Project
{
    public interface IProjectServiceClient
    {
        Task<List<ProjectDetailsResponse>> GetAllProjectByTeamId(long teamId);

        Task<ProjectDto> AddnewProject(string name, DateTime? deadline, Nullable<short> effortInHours, Nullable<decimal> effortInCurrency, long currencyId, long TeamId, long clientId);

        Task<List<ProjectDto>> GetAllProject();

        Task<bool> EditProject(long id, string name, DateTime? deadline, Nullable<short> effortInHours,Nullable<decimal> effortInCurrency, long currencyId, long TeamId, long statusId, long clientId);

        Task<bool> DeleteProject(long id);

        Task<ProjectDto> GetProjectById(long id);

        Task<ProjectDetailsResponse> GetDetailsProjectById(long id);

        Task<List<ProjectDto>> GetAllProjectByUser(string userEmail);

        Task<List<ProjectDto>> GetAllProjectByClient(string clientEmail);

    }   
}