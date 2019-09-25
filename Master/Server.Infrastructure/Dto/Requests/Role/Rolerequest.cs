using DataAccessLayer;

namespace Server.Infrastructure.Dto.Requests.Role
{
    public class Rolerequest
    {
        public string UserEmail { get; set; }

        public long Id { get; set; }

        public string Key { get; set; }

        public RoleTypeEnum RoleTypeId { get; set; }
    }
}