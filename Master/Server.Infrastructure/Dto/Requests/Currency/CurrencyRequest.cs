using System;

namespace Server.Infrastructure.Dto.Requests.Currency
{
    public class CurrencyRequest
    {
        public string Code { get; set; }

        public Nullable<bool> IsDefault { get; set; }

        public string PriceToDefault { get; set; }

        public long Id { get; set; }
    }
}
