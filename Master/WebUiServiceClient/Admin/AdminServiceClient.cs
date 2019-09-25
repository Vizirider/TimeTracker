using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer;
using Server.Infrastructure.Dto;
using Server.Infrastructure.Dto.Requests.Currency;
using Server.Infrastructure.Dto.Requests.Status;
using WebUiServiceClient.Common;

namespace WebUiServiceClient.Admin
{
    public class AdminServiceClient : IAdminServiceClient
    {
        HttpServices httpServices = new HttpServices();

        public async Task<CurrencyDto> AddnewCurrency(string code, Nullable<bool> isDefault, string priceToDefault)
        {
            string uri = "api/currency/AddnewCurrency";

            var request = new CurrencyRequest
            {
                Code = code,
                IsDefault = isDefault,
                PriceToDefault = priceToDefault
            };

            var addNewCurrencyToDb = await httpServices.Post<CurrencyDto, CurrencyRequest>(uri, request);

            if (addNewCurrencyToDb == null)
            {
                throw new Exception("Sikertelen mentés!");
            }

            return addNewCurrencyToDb;
        }

        public async Task<StatusDto> AddNewStatus(string name, StateEnum statusId)
        {
            string uri = "api/status/addnewstatus";

            var request = new StatusRequest
            {
                Name = name,
                status = statusId
            };

            var addNewStatus = await httpServices.Post<StatusDto, StatusRequest>(uri, request);

            if (addNewStatus == null)
            {
                throw new Exception("sikertelen mentés");
            }

            return addNewStatus;
        }

        public async Task<bool> DeleteCurrency(long id)
        {
            string uri = "api/currency/deletecurrency/";

            var DeleteCurrencyResult = await httpServices.Delete(uri + id);

            if (DeleteCurrencyResult == false)
            {
                throw new Exception("sikertelen törlés!");
            }

            return true;
        }

        public async Task<bool> DeleteStatus(long id)
        {
            string uri = "api/status/deletestatus/";

            var deleteStatusResult = await httpServices.Delete(uri + id);
            if (deleteStatusResult == false)
            {
                throw new Exception("sikertelen törlés!");
            }

            return true;
        }

        public async Task<bool> EditCurrency(long id, string code, Nullable<bool> isDefault, string priceToDefault)
        {
            string uri = "api/currency/editcurrency/";

            var request = new CurrencyRequest
            {
                Id = id,
                Code = code,
                PriceToDefault = priceToDefault,
                IsDefault = isDefault
            };

            var editCurrencyResult = await httpServices.Put<CurrencyRequest>(uri, request);

            if (editCurrencyResult == false)
            {
                throw new Exception("Sikertelen módosítás");
            }

            return editCurrencyResult;
        }

        public async Task<bool> EditStatus(long id, string name, StateEnum state)
        {
            string uri = "api/status/editstatus";
            bool newStatusToDb = false;

            var request = new StatusRequest
            {
                Id = id,
                Name = name,
                status = state
            };

            newStatusToDb = await httpServices.Put<StatusRequest>(uri, request);//httpServices.Post<StatusDto, StatusRequest>(uri, request);

            if (newStatusToDb == false)
            {
                throw new Exception("Sikertelen szerkesztés");
            }

            return newStatusToDb;
        }

        public async Task<List<CurrencyDto>> GetAllCurrency()
        {
            string uri = "api/currency/getallcurrency";

            var currenciesInDb = await httpServices.Get<List<CurrencyDto>>(uri);

            if (currenciesInDb == null)
            {
                throw new Exception("Not found!");
            }

            return currenciesInDb;
        }

        public async Task<List<StatusDto>> GetAllStatus()
        {
            string uri = "api/status/getallstatus";

            var statusList = await httpServices.Get<List<StatusDto>>(uri);

            if (statusList == null)
            {
                throw new Exception("Could not be found");
            }

            return statusList;
        }

        public async Task<CurrencyDto> GetCurrencyById(long id)
        {
            string uri = "api/currency/GetCurrencyById/";

            var currencyInDb = await httpServices.Get<CurrencyDto>(uri + id);

            if (currencyInDb == null)
            {
                throw new Exception("Could not be found");
            }

            return currencyInDb;
        }

        public async Task<StatusDto> GetStatusById(long id)
        {
            string uri = "api/status/getstatusbyid/";

            var statusInDb = await httpServices.Get<StatusDto>(uri + id);

            if (statusInDb == null)
            {
                throw new Exception("Not found!");
            }

            return statusInDb;
        }
    }
}