using GalaSoft.MvvmLight.Ioc;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUi.Model.Client;
using WebUi.Model.Project;
using WebUi.Model.Team;
using WebUi.ViewModel.Todo;
using WebUiServiceClient.Admin;
using WebUiServiceClient.Client;
using WebUiServiceClient.Project;
using WebUiServiceClient.Team;
using WebUiServiceClient.Todo;
using WebUiServiceClient.User;

namespace WebUi.Views.Admin
{
    public class AdminProjectController : Controller
    {

        private IProjectServiceClient _projectServiceClient;
        private IProjectServiceClient ProjectServiceClient => _projectServiceClient ?? (_projectServiceClient = SimpleIoc.Default.GetInstance<IProjectServiceClient>());

        private ITeamServiceClient _teamServiceClient;
        private ITeamServiceClient TeamServiceClient => _teamServiceClient ?? (_teamServiceClient = SimpleIoc.Default.GetInstance<ITeamServiceClient>());

        private IUserServiceClient _userServiceClient;
        private IUserServiceClient UserServiceClient => _userServiceClient ?? (_userServiceClient = SimpleIoc.Default.GetInstance<IUserServiceClient>());

        private IClientServicClient _clientServicClient;
        private IClientServicClient ClientServicClient => _clientServicClient ?? (_clientServicClient = SimpleIoc.Default.GetInstance<IClientServicClient>());

        private IAdminServiceClient _adminServiceClient;
        private IAdminServiceClient AdminServiceClient => _adminServiceClient ?? (_adminServiceClient = SimpleIoc.Default.GetInstance<IAdminServiceClient>());

        private ITodoServiceClient _todoServiceClient;
        private ITodoServiceClient TodoServiceClient => _todoServiceClient ?? (_todoServiceClient = SimpleIoc.Default.GetInstance<ITodoServiceClient>());


        // GET: AdminProject
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> ProjectList()
        {
            var model = new ProjectViewModel();

            try
            {
                model.ProjectList = await ProjectServiceClient.GetAllProject();
                model.TeamList= await TeamServiceClient.GetTeamsToUser(Session["User"].ToString());
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View(model);
        }

        public async Task<ActionResult> AddNewProject()
        {
            var projectViewmodel = new ProjectViewModel();
            if (Session["User"] != null && Session["Role"].ToString() == "Admin")
            { 
                try
                {
                    projectViewmodel.CurrencyList = await AdminServiceClient.GetAllCurrency(); 
                    projectViewmodel.TeamList = await TeamServiceClient.GetAllTeam();
                    projectViewmodel.ClientList = await ClientServicClient.GetAllClientList();
                }
                catch (Exception e)
                {
                    ViewBag.Message = "Sikertelen adat letöltés";
                }
            }

            return View(projectViewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddNewProject(ProjectViewModel model)
        {
            var projectViewmodel = new ProjectViewModel();

            try
            {
                await ProjectServiceClient.AddnewProject(model.Name, model.DeadLine, model.EffortInHours,
                    model.EffortInCurrency, model.CurrencyId, model.TeamId, model.ClientId);

                return RedirectToAction("ProjectList", "AdminProject");
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                projectViewmodel.CurrencyList = await AdminServiceClient.GetAllCurrency();
                projectViewmodel.TeamList = await TeamServiceClient.GetAllTeam();
                projectViewmodel.ClientList = await ClientServicClient.GetAllClientList();
            }
            return View(projectViewmodel);
        }

        public async Task<ActionResult> EditProject(long id)
        {
            var selectedProject = new ProjectViewModel();

            try
            {
                selectedProject.Project = await ProjectServiceClient.GetProjectById(id);
                selectedProject.CurrencyList = await AdminServiceClient.GetAllCurrency();
                selectedProject.TeamList = await TeamServiceClient.GetAllTeam();
                selectedProject.StatusList = await UserServiceClient.GetAllStatus();
                selectedProject.ClientList = await ClientServicClient.GetAllClientList();
                var team = await TeamServiceClient.GetTeamById(selectedProject.Project.TeamId);
                var currencyCode = await AdminServiceClient.GetCurrencyById(selectedProject.Project.CurrencyId);

                selectedProject.TeamName = team.Name;
                selectedProject.CurrencyCode = currencyCode.Code;
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }

            return View(selectedProject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditProject(ProjectViewModel model)
        {
            model.CurrencyList = await AdminServiceClient.GetAllCurrency();
            model.ClientList = await ClientServicClient.GetAllClientList();
            model.StatusList = await UserServiceClient.GetAllStatus();
            model.TeamList = await TeamServiceClient.GetAllTeam();

            try
            {
                await ProjectServiceClient.EditProject(model.Id, model.Project.Name, model.Project.DeadLine, model.Project.EffortInHours,
                    model.Project.EffortInCurrency, model.Project.CurrencyId, model.Project.TeamId, model.Project.StatusId, model.Project.ClientId);

                //return RedirectToAction("ProjectList", "AdminProject");
                ViewBag.Message = "Done :)";
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View(model);
        }

        public async Task<ActionResult> DeleteProject(long id)
        {
            var model = new ProjectViewModel();

            try
            {
                var result = await ProjectServiceClient.GetProjectById(id);

                model.Id = result.Id;
                model.Name = result.Name;
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                var result = await ProjectServiceClient.GetProjectById(id);

                model.Id = result.Id;
                model.Name = result.Name;
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteProject(ProjectViewModel model)
        {
            try
            {
                await ProjectServiceClient.DeleteProject(model.Id);

                return RedirectToAction("ProjectList");
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View(model);
        }

        public async Task<ActionResult> DetailsProject(long id)
        {
            var model = new ProjectViewModel();
            try
            {
                model.ProjectDetails = await ProjectServiceClient.GetDetailsProjectById(id);
                model.AllTodoList = await TodoServiceClient.GetTodoByProjectId(id);
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
                ViewBag.Error = -1;
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
                ViewBag.Error = -1;
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
                ViewBag.Error = -1;
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
