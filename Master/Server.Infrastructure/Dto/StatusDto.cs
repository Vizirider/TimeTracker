using DataAccessLayer;

namespace Server.Infrastructure.Dto
{
    public class StatusDto : EntityBaseDto
    {
        public string Name { get; set; }

        public StateEnum StateTypeId { get; set; }

        public long Id { get; set; }

    }
}