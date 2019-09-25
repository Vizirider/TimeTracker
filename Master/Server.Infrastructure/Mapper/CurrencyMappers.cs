namespace Server.Infrastructure.Mapper
{
    using DataAccessLayer;

    using Server.Infrastructure.Dto;

    public static class CurrencyMappers
    {
        public static CurrencyDto Map(this Currency source)
        {
            var target = new CurrencyDto
            {
                Code = source.Code,
                IsDefault = source.IsDefault,
                PriceToDefault = source.PriceToDefault,
                Id = source.Id
            };

            return target;
        }
    }
}
