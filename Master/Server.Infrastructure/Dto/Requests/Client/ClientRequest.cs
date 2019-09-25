using System.ComponentModel.DataAnnotations;

namespace Server.Infrastructure.Dto.Requests.Client
{
    public class ClientRequest
    {
        [Required]
        public string Website { get; set; }

        [Required]
        public long TeamId { get; set; }

        public long Id { get; set; }

        [Required]
        public long UserId { get; set; }

        [Required]
        public string ClientName { get; set; }

        public string Email { get; set; }
    }
}