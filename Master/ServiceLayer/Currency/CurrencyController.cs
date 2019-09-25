using BusinessLogicLayer.Currency;
using Server.Infrastructure.Dto;
using Server.Infrastructure.Dto.Requests.Currency;
using Server.Infrastructure.Mapper;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Web.Http;

namespace ServiceLayer.Currency
{
    public class CurrencyController : ApiController
    {
        private static readonly CurrencyLogic _currencyLogic = new CurrencyLogic();

        [HttpPost]
        public CurrencyDto AddnewCurrency(CurrencyRequest request)
        {
            try
            {
                return _currencyLogic.AddnewCurrency(request.Code, request.IsDefault, request.PriceToDefault).Map();
            }
            catch (Exception e)
            {
                throw new FaultException("Sikertelen Currency regisztrálás!");
            }
        }

        [HttpPost]
        public CurrencyDto GetCurrencyByCode(CurrencyRequest request)
        {
            try
            {
                return _currencyLogic.GetCurrencyByCode(request.Code).Map();
            }
            catch (Exception e)
            {
                throw new FaultException("A kért Currency nem található!");
            }
        }

        [HttpGet]
        public List<CurrencyDto> GetAllCurrency()
        {
            try
            {
                return _currencyLogic.GetAll();
            }
            catch (Exception e)
            {
                throw new FaultException("Hiba történt a currency lista lekérdezés során!");
            }
        }

        [HttpPut]
        public bool EditCurrency(CurrencyRequest request)
        {
            try
            {
                return _currencyLogic.EditCurrency(request.Id, request.Code, request.IsDefault, request.PriceToDefault);
            }
            catch (Exception e)
            {
                throw new FaultException("Sikertelen szerkesztés");
            }
        }

        [HttpGet]
        public CurrencyDto GetCurrencyById(long id)
        {
            try
            {
                return _currencyLogic.GetCurrencyById(id).Map();
            }
            catch (Exception e)
            {
                throw new FaultException("Not found such currency!");
            }
        }

        [HttpDelete]
        public bool DeleteCurrency(long id)
        {
            try
            {
                return _currencyLogic.DeleteCurrency(id);
            }
            catch (Exception e)
            {
                throw new FaultException("Sikertelen törlés!");
            }
        }
    }
}
