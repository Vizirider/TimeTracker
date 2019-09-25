using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Infrastructure.Dto;
using Server.Infrastructure.Dto.Requests.Todo;
using WebUiServiceClient.Common;

namespace WebUiServiceClient.Todo
{
    public class TodoServiceClient : ITodoServiceClient
    {
        HttpServices httpServices = new HttpServices();

        public async Task<List<TodoDto>> GetAllTodo()
        {
            string uri = "api/todo/getalltodo";

            var todoListInDb = await httpServices.Get<List<TodoDto>>(uri);

            if (todoListInDb == null)
            {
                throw new Exception("The list could not be found");
            }

            return todoListInDb;
        }

        public async Task<TodoDto> GetTodoById(long id)
        {
            string uri = "api/todo/gettodobyid/";

            var todoInDb = await httpServices.Get<TodoDto>(uri + id);

            if (todoInDb == null)
            {
                throw new Exception("Could not be found");
            }

            return todoInDb;
        }

        public async Task<TodoDto> AddTodo(string title, string content, long projectId)
        {
            string uri = "api/todo/addtodo";

            var request = new TodoRequest
            {
                Content = content,
                Title = title,
                ProjectId = projectId
            };

            var addTodoToDb = await httpServices.Post<TodoDto, TodoRequest>(uri, request);

            if (addTodoToDb == null)
            {
                throw new Exception("Adding to the database was failed");
            }

            return addTodoToDb;
        }

        public async Task<bool> EditTodo(long id, long statusId, string title, string content)
        {
            string uri = "api/todo/edittodo";

            var request = new TodoRequest
            {
                Id = id,
                StatusId = statusId,
                Title = title,
                Content = content
            };

            var editTodoInDb = await httpServices.Put(uri, request);

            if (editTodoInDb == false)
            {
                throw new Exception("The edition was failed");
            }

            return editTodoInDb;
        }

        public async Task<bool> DeleteTodo(long id)
        {
            string uri = "api/todo/deletetodo/";

            var deleteTodoFromDb = await httpServices.Delete(uri + id);

            if (deleteTodoFromDb == false)
            {
                throw new Exception("The deletion was falied");
            }

            return deleteTodoFromDb;
        }

        public async Task<List<TodoDto>> GetTodoByProjectId(long id)
        {
            string uri = "api/todo/GetTodoByProjectId/";

            var todoListInDbByTeamId = await httpServices.Get<List<TodoDto>>(uri + id);

            if (todoListInDbByTeamId == null)
            {
                throw new Exception("Could not found");
            }

            return todoListInDbByTeamId;
        }
    }
}