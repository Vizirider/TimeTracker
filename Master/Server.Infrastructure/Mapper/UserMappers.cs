namespace Server.Infrastructure.Mapper
{
    using DataAccessLayer;

    using Server.Infrastructure.Dto;

    public static class UserMappers
    {
        public static UserDto Map(this User source)
        {
            var target = new UserDto
            {
                Id = source.Id,
                Email = source.Email,
                Name = source.Name,
                Password = source.Password,
                Token = source.Token,
                Phone = source.Phone,
                RoleId = source.RoleId
            };

            return target;
        }
    }
}