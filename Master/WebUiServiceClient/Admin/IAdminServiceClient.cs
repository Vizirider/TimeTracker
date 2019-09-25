using System;
using DataAccessLayer;
using Server.Infrastructure.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebUiServiceClient.Admin
{
    public interface IAdminServiceClient
    {
        Task<StatusDto> AddNewStatus(string name, StateEnum statusId);

        Task<bool> EditStatus(long id, string name,  StateEnum statusId);

        Task<List<StatusDto>> GetAllStatus();

        Task<StatusDto> GetStatusById(long id);

        Task<bool> DeleteStatus(long id);

        Task<CurrencyDto> AddnewCurrency(string code, Nullable<bool> isDefault, string priceToDefault);

        Task<List<CurrencyDto>> GetAllCurrency();

        Task<bool> EditCurrency(long id, string code, Nullable<bool> isDefault, string priceToDefault);

        Task<CurrencyDto> GetCurrencyById(long id);

        Task<bool> DeleteCurrency(long id);

        
    }
}