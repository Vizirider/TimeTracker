namespace Server.Infrastructure.Dto.Requests.User
{
    public class ForgotPassword
    {
        public string Email { get; set; }

        // todo : encoding
        public string Password { get; set; }

        public string Token { get; set; }
    }
}