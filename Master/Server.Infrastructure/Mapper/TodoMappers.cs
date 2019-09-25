using DataAccessLayer;
using Server.Infrastructure.Dto;

namespace Server.Infrastructure.Mapper
{
    public static class TodoMappers
    {
        public static TodoDto Map(this Todo source)
        {
            var target = new TodoDto()
            {
                Id   = source.Id,
                StatusId = source.StatusId,
                Content = source.Content,
                Title = source.Title,
                ProjectId = source.ProjectId
            };

            return target;
        }
    }
}