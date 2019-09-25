using System;

namespace Server.Infrastructure.Dto
{
    public class CurrencyDto : EntityBaseDto
    {
        public string Code { get; set; }

        public Nullable<bool> IsDefault { get; set; }

        public string PriceToDefault { get; set; }

        public long Id { get; set; }

    }
}