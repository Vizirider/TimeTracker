namespace Server.Infrastructure.Dto.Requests.Todo
{
    public class TodoRequest
    {
        public long StatusId { get; set; }

        public long Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public long  ProjectId { get; set; }

        public long TimeInSeconds { get; set; }
    
        public string Comment { get; set; }
    }
}