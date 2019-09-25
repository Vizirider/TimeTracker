using System.Collections.Specialized;

namespace Server.Infrastructure.Dto.Requests.User
{
    public class AddClientRequest 
    {
        public string Token { get; set; }

        public string Name { get; set; }        
        
        public string Phone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public long TeamId { get; set; }

        public string Website { get; set; }
    }
}