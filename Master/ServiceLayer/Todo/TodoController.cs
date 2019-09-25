using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceModel;
using System.Web.Http;
using BusinessLogicLayer.Todo;
using Server.Infrastructure.Dto;
using Server.Infrastructure.Dto.Requests.Todo;
using Server.Infrastructure.Mapper;

namespace ServiceLayer.Todo
{
    public class TodoController : ApiController
    {
        private static readonly TodoLogic _todoLogic = new TodoLogic();


        [HttpGet]
        public List<TodoDto> GetAllTodo()
        {
            try
            {
                return _todoLogic.GetAllTodo();
            }
            catch (Exception e)
            {
                throw new FaultException("The list could not be found");
            }
        }

        [HttpGet]
        public TodoDto GetTodoById(long id)
        {
            TodoDto todo = new TodoDto();

            try
            {
                return _todoLogic.GetTodoById(id);
            }
            catch (Exception e)
            {
                throw new FaultException("Could not be found ");
            }
        }

        [HttpGet]
        public List<TodoDto> GetTodoByProjectId(long id)
        {
            try
            {
                return _todoLogic.GetTodoByProjectId(id);
            }
            catch (Exception e)
            {
                throw new FaultException("Could not befound");
            }
        }


        [HttpPost]
        public TodoDto AddTodo(TodoRequest request)
        {
            try
            {
                return _todoLogic.AddTodo(request).Map();
            }
            catch (Exception e)
            {
                throw new FaultException("Adding to the database was failed");
            }
        }

        [HttpPut]
        public bool EditTodo(TodoRequest request)
        {
            try
            {
                return _todoLogic.EditTodo(request);
            }
            catch (Exception e)
            {
                throw new FaultException("The edition was failed");
            }
        }

        [HttpDelete]
        public bool DeleteTodo(long id)
        {
            try
            {
                return _todoLogic.DeleteTodo(id);
            }
            catch (Exception e)
            {
                throw new FaultException("The deletion was falied");
            }
        }
    }
}
