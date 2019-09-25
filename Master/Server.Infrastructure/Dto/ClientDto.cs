using Server.Infrastructure.Dto;

namespace Server.Infrastructure.Dto
{
    public class ClientDto : UserDto
    {
        public string Website { get; set; }

        public long TeamId { get; set; }

        public long Id { get; set; }

        public long UserId { get; set; }
    }
}