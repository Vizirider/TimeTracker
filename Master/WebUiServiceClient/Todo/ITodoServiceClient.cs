using Server.Infrastructure.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebUiServiceClient.Todo
{
    public interface ITodoServiceClient
    {
        Task<List<TodoDto>> GetAllTodo();

        Task<TodoDto> GetTodoById(long id);

        Task<TodoDto> AddTodo(string title, string content, long clientId);

        Task<bool> EditTodo(long id, long statusId, string title, string content);

        Task<bool> DeleteTodo(long id);

        Task<List<TodoDto>> GetTodoByProjectId(long id);
    }
}