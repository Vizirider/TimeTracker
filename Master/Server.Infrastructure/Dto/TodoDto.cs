using System.Security.AccessControl;
using DataAccessLayer;

namespace Server.Infrastructure.Dto
{
    public class TodoDto : EntityBaseDto
    {
        public long StatusId { get; set; }

        public string StatusName { get; set; }  

        public long Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public long  ProjectId { get; set; }

        public string  ProjectName { get; set; }

        public long TimeInSeconds { get; set; }

        public string Comment { get; set; }
    }
}