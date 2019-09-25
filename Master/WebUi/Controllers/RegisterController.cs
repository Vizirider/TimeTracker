using GalaSoft.MvvmLight.Ioc;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUi.Model.Register;
using WebUiServiceClient.Client;
using WebUiServiceClient.Team;
using WebUiServiceClient.User;

namespace WebUi.Controllers
{
    public class RegisterController : Controller
    {
        private IUserServiceClient _userServiceClient;
        private IUserServiceClient UserServiceClient => _userServiceClient ?? (_userServiceClient = SimpleIoc.Default.GetInstance<IUserServiceClient>());

        private ITeamServiceClient _teamServiceClient;
        private ITeamServiceClient TeamServiceClient => _teamServiceClient ?? (_teamServiceClient = SimpleIoc.Default.GetInstance<ITeamServiceClient>());

        private IClientServicClient _clientServicClient;
        private IClientServicClient ClientServicClient => _clientServicClient ?? (_clientServicClient = SimpleIoc.Default.GetInstance<IClientServicClient>());

        // GET: RegisterUser
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> RegisterUser(AddUserRequestView addUserUserRequest)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var reult = await  UserServiceClient.RegisterUser(addUserUserRequest);
                    
                    if (Session["User"] != null && Session["Role"].ToString() == "Admin")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        ViewBag.Message = "Siker :)";

                        ModelState.Clear();
                    } 
                }
                catch (Exception e)
                {
                    ViewBag.Message = e.Message;
                }
            }
            return View();
        }

        
        public async Task<ActionResult> RegisterClient()
        {
            var modelView = new AddClientRequestView();

            if (Session["User"] != null && Session["Role"].ToString() == "Admin")
            { 
                try
                {
                    modelView.TeamListForUser = await TeamServiceClient.GetAllTeam();
                }
                catch (Exception e)
                {
                    ViewBag.Message = e.Message;
                }
            }

            return View(modelView);
        }

        [HttpPost]
        public async Task<ActionResult> RegisterClient(AddClientRequestView addClientRequest)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    await ClientServicClient.RegisterClient(addClientRequest);
                    ViewBag.Message = "Done :)";

                    //return RedirectToAction("RegisterClient");
                }
                catch (Exception e)
                {
                    ViewBag.Message = "Sikertelen regisztráció!!";
                }
            }

            addClientRequest.TeamListForUser = await TeamServiceClient.GetAllTeam();

            return View(addClientRequest);
        }
    }
}
