using DataAccessLayer;

namespace Server.Infrastructure.Dto.Requests.Status
{
    public class StatusRequest
    {
        public string Name { get; set; }

        public StateEnum status { get; set; }

        public long Id { get; set; }
    }
}