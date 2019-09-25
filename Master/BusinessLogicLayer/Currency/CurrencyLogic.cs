using System;
using Server.Infrastructure.Dto;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace BusinessLogicLayer.Currency
{
    using DataAccessLayer;

    public class CurrencyLogic
    {
        public Currency AddnewCurrency(string code, Nullable<bool> isDefault, string priceToDefault)
        {
            Currency newCurrency = new Currency();

            using (var db = new TimeTrackerModelContainer())
            {
                newCurrency.Code = code;
                newCurrency.IsDefault = isDefault;
                newCurrency.PriceToDefault = priceToDefault;

                db.Currency.Add(newCurrency);
                db.SaveChanges();
            }

            return newCurrency;
        }

        public Currency GetCurrencyByCode(string code)
        {
            Currency currency;

            using (var db = new TimeTrackerModelContainer())
            {
                currency = db.Currency.First(x => x.Code == code);

                if (currency == null)
                {
                    throw new Exception("Nincs Currency megadva");
                }
            }

            return currency;
        }

        public List<CurrencyDto> GetAll()
        {
            List<CurrencyDto> currencyList = new List<CurrencyDto>();

            using (var db = new TimeTrackerModelContainer())
            {
                var tempList = db.Currency.AsEnumerable().ToList();

                foreach (var VARIABLE in tempList)
                {
                    currencyList.Add(new CurrencyDto
                        {
                            Id = VARIABLE.Id,
                            Code = VARIABLE.Code,
                            PriceToDefault = VARIABLE.PriceToDefault,
                            IsDefault = VARIABLE.IsDefault
                        }
                    );
                }
            }

            return currencyList;
        }

        public bool EditCurrency(long id, string code, Nullable<bool> isDefault, string priceToDefault)
        {
            bool flag = false;

            Currency newCurrency = new Currency();
    
  
            using (var db = new TimeTrackerModelContainer())
            {
                var result = db.Currency.First(x => x.Id == id);

                newCurrency.Id = result.Id;
                newCurrency.Code = code;
                newCurrency.IsDefault = isDefault;
                newCurrency.PriceToDefault = priceToDefault;

                var s = db.Set<Currency>().Local.FirstOrDefault(x => x.Id == id);

                if (s != null)
                {
                    db.Entry(s).State = EntityState.Detached;
                }

                if (result.Id == id)
                {

                    db.Entry(newCurrency).State = EntityState.Modified;

                    db.SaveChanges();

                    flag = true;
                }
            }

            return flag;
        }

        public Currency GetCurrencyById(long id)
        {
            Currency resultCurrency;

            using (var db = new TimeTrackerModelContainer())
            {
                resultCurrency = db.Currency.First(x => x.Id == id);
            }

            return resultCurrency;
        }

        public bool DeleteCurrency(long id)
        {
            bool flag = false;

            using (var db = new TimeTrackerModelContainer())
            {
                var result = db.Currency.First(x => x.Id == id);
                db.Currency.Remove(result);
                db.SaveChanges();

                flag = true;
            }

            return flag;
        }

    }
}
