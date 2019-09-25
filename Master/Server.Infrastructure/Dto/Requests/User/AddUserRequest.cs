namespace Server.Infrastructure.Dto.Requests.User
{
    public class AddUserRequest
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public long RoleId { get; set; }
        public string Token { get; set; }
    }
}