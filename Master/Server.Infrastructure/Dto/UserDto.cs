namespace Server.Infrastructure.Dto
{
    public class UserDto : EntityBaseDto
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public long Id { get; set; }

        public long RoleId { get; set; }

        public string RoleName { get; set; }

        public string Token { get; set; }

    }
}