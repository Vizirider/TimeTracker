namespace Server.Infrastructure.Dto.Requests.User
{
    public class LoginRequest
    {
        public string Email { get; set; }

        // todo : encoding
        public string Password { get; set; }
    }
}