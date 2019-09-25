using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BusinessLogicLayer.Status;
using BusinessLogicLayer.TimeRecord;
using Server.Infrastructure.Dto;
using Server.Infrastructure.Dto.Requests.Todo;
using Server.Infrastructure.Enums;

namespace BusinessLogicLayer.Todo
{
    using DataAccessLayer;
    public class TodoLogic
    {
        public int TimeInSeconds { get; private set; }
        public long Id { get; private set; }

        public List<TodoDto> GetAllTodo()
        {
            var todoList = new List<TodoDto>();

            using (var db = new TimeTrackerModelContainer())
            {
                var list = db.Todo.AsEnumerable().ToList();

                foreach (var tempList in list)
                {
                    todoList.Add(new TodoDto
                    {
                        Id = tempList.Id,
                        StatusId = tempList.StatusId,
                        Content = tempList.Content,
                        Title = tempList.Title,
                        StatusName = tempList.Status.Name
                    });
                }
            }

            return todoList;
        }

        public TodoDto GetTodoById(long id)
        {
            var todo = new TodoDto();
            var timerecord = new TimeRecord();

            using (var db = new TimeTrackerModelContainer())
            {
                var result = db.Todo.First(x => x.Id == id);
                todo.StatusName = db.Status.First(x => x.Id == result.StatusId).Name;
                todo.Id = result.Id;
                todo.Title = result.Title;
                todo.StatusId = result.StatusId;
                todo.Content = result.Content;
            }

            return todo;
        }

        public Todo AddTodo(TodoRequest request)
        {
            var statusLogic = new StatusLogic();
            var newtimerecordLogic = new TimeRecord();
            var newTodo = new Todo
            {
                StatusId = statusLogic.GetStatus(States.New).Id,
                Content = request.Content,
                Title = request.Title,
                ProjectId = request.ProjectId,
                TimeInSeconds = request.TimeInSeconds,
                Comment = request.Comment
            };

            using (var db = new TimeTrackerModelContainer())
            {
           
                db.Todo.Add(newTodo);
                db.SaveChanges();
            }
            
            return newTodo;
        }

        public bool EditTodo(TodoRequest request)
        {
            bool flag = false;

            using (var db = new TimeTrackerModelContainer())
            {
                var result = db.Todo.First(x => x.Id == request.Id);
                result.Content = request.Content;
                result.StatusId = request.StatusId;
                result.Title = request.Title;
                result.TimeInSeconds = result.TimeInSeconds;
                result.Comment = result.Comment;

                db.Entry(result).State = EntityState.Modified;
                db.SaveChanges();

                flag = true;
            }

            return flag;
        }

        public bool DeleteTodo(long id)
        {
            bool flag = false;
            using (var db = new TimeTrackerModelContainer())
            {
                var todo = db.Todo.FirstOrDefault(x => x.Id == id);

                db.Todo.Remove(todo);
                db.SaveChanges();

                flag = true;
            }

            return flag;
        }

        public List<TodoDto> GetTodoByProjectId(long id)
        {
            var todo = new List<TodoDto>();

            using (var db = new TimeTrackerModelContainer())
            {
                var dbResult = db.Todo.Where(x => x.ProjectId == id)
                    .Include(x => x.TimeRecord)
                    .ToList();

                var result = dbResult.Select(x => MapTodoDto(x));
            }

            return todo;
        }

        private static TodoDto MapTodoDto(Todo source)
        {
            return new TodoDto
            {
                Id = source.Id,
                StatusId = source.StatusId,
                Title = source.Title,
                Content = source.Content,
                StatusName = source.Status.Name,
                ProjectId = source.ProjectId,
                ProjectName = source.Project.Name,
                TimeInSeconds = source.TimeRecord.Sum(x => x.TimeInSeconds),
                Comment = source.Comment
            };
        }
    }
}