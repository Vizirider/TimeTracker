namespace Server.Infrastructure.Mapper
{
    using DataAccessLayer;

    using Server.Infrastructure.Dto;

    public static class ClientMappers
    {
        public static ClientDto Map(this Client source)
        {
            var target = new ClientDto
            {
                Id = source.Id,
                Website = source.Website,
                TeamId = source.TeamId,
                UserId = source.UserId
            };

            return target;
        }
    }
}