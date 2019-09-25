using GalaSoft.MvvmLight.Ioc;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUi.Model.Client;
using WebUi.Model.Project;
using WebUi.Model.Team;
using WebUi.ViewModel.Todo;
using WebUiServiceClient.Client;
using WebUiServiceClient.Project;
using WebUiServiceClient.Team;
using WebUiServiceClient.Todo;
using WebUiServiceClient.User;

namespace WebUi.Controllers
{
    public class ProjectController : Controller
    {
        private IProjectServiceClient _projectServiceClient;
        private IProjectServiceClient ProjectServiceClient => _projectServiceClient ?? (_projectServiceClient = SimpleIoc.Default.GetInstance<IProjectServiceClient>());

        private IUserServiceClient _userServiceClient;
        private IUserServiceClient UserServiceClient => _userServiceClient ?? (_userServiceClient = SimpleIoc.Default.GetInstance<IUserServiceClient>());

        private ITeamServiceClient _teamServiceClient;
        private ITeamServiceClient TeamServiceClient => _teamServiceClient ?? (_teamServiceClient = SimpleIoc.Default.GetInstance<ITeamServiceClient>());

        private IClientServicClient _clientServicClient;
        private IClientServicClient ClientServicClient => _clientServicClient ?? (_clientServicClient = SimpleIoc.Default.GetInstance<IClientServicClient>());

        private ITodoServiceClient _todoServiceClient;
        private ITodoServiceClient TodoServiceClient => _todoServiceClient ?? (_todoServiceClient = SimpleIoc.Default.GetInstance<ITodoServiceClient>());

        // GET
        public ActionResult Index()
        {
            return
            View();
        }

        public async Task<ActionResult> DetailsProjectList(long id)
        {
            var model = new ProjectViewModel();
            try
            {
                model.ProjectDetails = await ProjectServiceClient.GetDetailsProjectById(id);
                model.AllTodoList = await TodoServiceClient.GetTodoByProjectId(model.ProjectDetails.TeamId);
                if (model.AllTodoList.Count >= 1)
                {
                    ViewBag.Flag = "1";
                }
                else
                {
                    ViewBag.Flag = "0";
                }


            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }

            return View(model);
        }

        public async Task<ActionResult> ProjectList()
        {
            var modelView = new ProjectViewModel();

            if (Session["User"] != null)
            {
                var userEmail = Session["User"].ToString();

                try
                {
                    if (Session["Role"].ToString() == "Client")
                    {

                        modelView.ProjectList = await ProjectServiceClient.GetAllProjectByClient(userEmail);
                    }
                    else
                    {
                        modelView.ProjectList = await ProjectServiceClient.GetAllProjectByUser(userEmail);
                    }
                }

                catch (Exception e)
                {
                    ViewBag.Message = e.Message;
                }
            }

            return View(modelView);
        }

        [HttpPost]
        public async Task<ActionResult> ProjectList(ProjectViewModel model)
        {
            if (Session["User"] != null)
            {
                var userEmail = Session["User"].ToString();

                try
                {
                    model.TeamList = await TeamServiceClient.GetTeamsToUser(userEmail);
                    model.TeamListForTeam = await ProjectServiceClient.GetAllProjectByTeamId(model.TeamId);
                }
                catch (Exception e)
                {
                    ViewBag.Message = e.Message;
                }
            }

            return View(model);
        }

        public async Task<ActionResult> DetailsTeam(long id)
        {
            var model = new TeamDetailsViewModel();

            try
            {
                model.TeamDetailsList = await TeamServiceClient.GetTeamDetails(id);
                model.TeamName = model.TeamDetailsList[0].TeamName;
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }

            return View(model);
        }

        public async Task<ActionResult> DetailsClient(long id)
        {
            var model = new ClientDetailsViewModel();

            try
            {
                model.ClientDetails = await ClientServicClient.GetDetailsClientById(id);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }

            return View(model);
        }

        public async Task<ActionResult> TodoListByTeamId()
        {
            var model = new TodoViewModel();

            try
            {
                //var result = await TodoServiceClient.GetTodoByTeamId(id);
                model.TodoList = await TodoServiceClient.GetAllTodo();
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View();
        }
    }
}