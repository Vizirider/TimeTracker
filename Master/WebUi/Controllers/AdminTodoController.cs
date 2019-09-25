using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using GalaSoft.MvvmLight.Ioc;
using WebUi.ViewModel.Todo;
using WebUiServiceClient.Admin;
using WebUiServiceClient.Project;
using WebUiServiceClient.Todo;

namespace WebUi.Controllers
{
    public class AdminTodoController : Controller
    {
        private ITodoServiceClient _todoServiceClient;
        private ITodoServiceClient TodoServiceClient => _todoServiceClient ?? (_todoServiceClient = SimpleIoc.Default.GetInstance<ITodoServiceClient>());

        private IAdminServiceClient _adminServiceClient;
        private IAdminServiceClient AdminServiceClient => _adminServiceClient ?? (_adminServiceClient = SimpleIoc.Default.GetInstance<IAdminServiceClient>());

        private IProjectServiceClient _projectServiceClient;
        private IProjectServiceClient ProjectServiceClient => _projectServiceClient ?? (_projectServiceClient = SimpleIoc.Default.GetInstance<IProjectServiceClient>());

        // GET: AdminTodo
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> TodoList()
        {
            var model = new TodoViewModel();
            try
            {
                 model.TodoList = await TodoServiceClient.GetAllTodo();
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View(model);
        }

        public async Task<ActionResult> AddTodo()
        {
            var model = new TodoViewModel();

            try
            {
                model.StatusList = await AdminServiceClient.GetAllStatus();
                model.ProjectList = await ProjectServiceClient.GetAllProject();
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AddTodo(TodoViewModel model)
        {
            try
            {
                var result = await TodoServiceClient.AddTodo(model.Title, model.Content, model.ProjectId);

                return RedirectToAction("TodoList");
            }
            catch (Exception e)
            {
                model.StatusList = await AdminServiceClient.GetAllStatus();
                ViewBag.Message = e.Message;
            }
            return View(model);
        }

        public async Task<ActionResult> EditTodo(long id)
        {
            var model = new TodoViewModel();

            try
            {
                model.Todo = await TodoServiceClient.GetTodoById(id);
                model.StatusList = await AdminServiceClient.GetAllStatus();
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> EditTodo(TodoViewModel model)
        {
            try
            {
                var edit = await TodoServiceClient.EditTodo(model.Id, model.Todo.StatusId, model.Todo.Title, model.Todo.Content);

                return RedirectToAction("TodoList");
            }
            catch (Exception e)
            {
                model.StatusList = await AdminServiceClient.GetAllStatus();
                ViewBag.Message = e.Message;
            }
            return View(model);
        }

        public async Task<ActionResult> DeleteTodo(long id)
        {
            var model= new TodoViewModel();

            try
            {
                model.Todo = await TodoServiceClient.GetTodoById(id);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteTodo(TodoViewModel model)
        {
            try
            {
                await TodoServiceClient.DeleteTodo(model.Id);

                return RedirectToAction("TodoList");
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View();
        }
    }
}