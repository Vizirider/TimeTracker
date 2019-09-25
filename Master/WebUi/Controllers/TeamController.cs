using GalaSoft.MvvmLight.Ioc;
using Server.Infrastructure.Dto;
using Server.Infrastructure.Dto.Requests.Team;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Server.Infrastructure.Dto.Responses;
using WebUi.Model.Team;
using WebUiServiceClient.Admin;
using WebUiServiceClient.Team;
using WebUiServiceClient.User;

namespace WebUi.Controllers
{
    public class TeamController : Controller
    {
        private ITeamServiceClient _teamServiceClient;
        private ITeamServiceClient TeamServiceClient => _teamServiceClient ?? (_teamServiceClient = SimpleIoc.Default.GetInstance<ITeamServiceClient>());

        private IUserServiceClient _userServiceClient;
        private IUserServiceClient UserServiceClient => _userServiceClient ?? (_userServiceClient = SimpleIoc.Default.GetInstance<IUserServiceClient>());

        private IAdminServiceClient _adminServiceClient;
        private IAdminServiceClient AdminServiceClient => _adminServiceClient ?? (_adminServiceClient = SimpleIoc.Default.GetInstance<IAdminServiceClient>());

        // GET: Team
        public ActionResult Index()
        {
            return View();
        }
      
        public async Task<ActionResult> TeamList()
        {
            var modelView = new TeamViewModel();
            if (Session["User"] != null)
            {
                var userEmail = Session["User"].ToString();

                try
                {
                    if (Session["Role"].ToString() == "Admin")
                    {
                        modelView.TeamList = await TeamServiceClient.GetAllTeam();
                    }
                    else
                    {
                        modelView.TeamList = await TeamServiceClient.GetTeamsToUser(userEmail);
                    }
                }

                catch (Exception e)
                {
                    ViewBag.Message = "Sikertelen lekérdezés!!";

                    return View();
                }
            }

            return View(modelView);
        }

        public async Task<ActionResult> AddNewTeam()
        {
            var model = new TeamDetailsViewModel();

            try
            {
                model.CurrencyList = await AdminServiceClient.GetAllCurrency();
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddNewTeam(TeamDetailsViewModel newTeam)
        {
            if (newTeam.TeamName != null)
            {
                var userEmail = Session["User"].ToString();

                try
                {
                    await TeamServiceClient.AddNewTeam(newTeam.TeamName, "0", "0", 1, userEmail);

                    return RedirectToAction("TeamList", "Team");
                }
                catch (Exception e)
                {
                    ViewBag.Message = "Hiba történt a csapat hozzáadás során!";
                }
            }

            return View();
        }

        public async Task<ActionResult> EditTeam(int id)
        {
            var team = new TeamDetailsResponseDto();
            var teamView= new TeamDetailsViewModel();

            try
            {
                teamView.CurrencyList = await AdminServiceClient.GetAllCurrency();
                var dd = await TeamServiceClient.GetTeamById(id);
               
                teamView.TeamName = dd.Name;
                teamView.Id = dd.Id;
                teamView.PrivatePrice = team.PrivatePrice;
                teamView.PublicPrice = team.PublicPrice;
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View(teamView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditTeam(TeamDetailsViewModel model)
        {
            try
            {
                await TeamServiceClient.EditTeam(model.Id, model.TeamName);

                return RedirectToAction("TeamList", "Team");
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View();
        }


        public async Task<ActionResult> EditTeamDetails(long id)
        {
            var model = new TeamDetailsViewModel();

            try
            {
                model.CurrencyList = await AdminServiceClient.GetAllCurrency();
                model.TeamDetails = await TeamServiceClient.GetTeamDetailsForEdit(id);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditTeamDetails(TeamDetailsViewModel model)
        {
            try
            {
                var result = await TeamServiceClient.EditTeamDetails(model.Id, model.TeamDetails.TeamName, model.TeamDetails.PublicPrice,
                    model.TeamDetails.PrivatePrice, model.TeamDetails.CurrencyId);
                model.TeamDetails = await TeamServiceClient.GetTeamDetailsForEdit(model.Id);

                return RedirectToAction("DetalisTeam","Team", new {id = model.TeamDetails.TeamId});
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View();
        }

        public async Task<ActionResult> DeleteTeam(long id)
        {
            var team = new TeamDto();
            var teamView = new TeamViewModel();

            try
            {
                team = await TeamServiceClient.GetTeamById(id);
                teamView.Name = team.Name;
                teamView.Id = team.Id;
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View(teamView);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteTeam(TeamViewModel viewModel)
        {
            try
            {
                await TeamServiceClient.DeleteTeamAndUserLink(viewModel.Id);

                return RedirectToAction("TeamList");
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View(viewModel);
        }

        public async Task<ActionResult> DetalisTeam( long id)
        {
            var model = new TeamDetailsViewModel();
            try
            {
                model.TeamDetailsList = await TeamServiceClient.GetTeamDetails(id);
                model.TeamName = model.TeamDetailsList[0].TeamName;
                model.TeamId = model.TeamDetailsList[0].TeamId;
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View(model);
        }

        public async Task<ActionResult> AddNewUserForTeam()
        {
            var addNewUser = new AddNewUserToTeamViewModel();
           
            if (Session["User"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            try
            {
                if (Session["User"] != null && Session["Role"].ToString() == "Admin")
                {
                    addNewUser.TeamList = await TeamServiceClient.GetAllTeam();
                    addNewUser.CurrencyList = await TeamServiceClient.GetAllCurrency();
                }
                else
                {
                    addNewUser.TeamList = await TeamServiceClient.GetTeamsToUser(Session["User"].ToString());
                    addNewUser.CurrencyList = await TeamServiceClient.GetAllCurrency();
                }

                addNewUser.UserList = await UserServiceClient.GetAllUser();
                
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View(addNewUser);
        }

        [HttpPost]
        public async Task<ActionResult> AddNewUserForTeam(AddNewUserToTeamViewModel model)
        {
            AddNewUserToTeamViewModel addNewUser;
            var request = new AddNewUserToTeamRequest
            {
                CurrencyId = model.CurrencyId,
                TeamId = model.Id,
                UserID = model.UserId,
                PrivatePrice = model.PrivatePrice,
                PublicPrice = model.PublicPrice

            };

            try
            {
                await TeamServiceClient.AddNewUserToTeam(request);
                return RedirectToAction("DetalisTeam","Team", new {id = request.TeamId});
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;

                if (Session["User"] != null && Session["Role"].ToString() == "Admin")
                {
                    addNewUser = new AddNewUserToTeamViewModel
                    {
                        TeamList = await TeamServiceClient.GetAllTeam(),
                        UserList = await UserServiceClient.GetAllUser(),
                        CurrencyList = await TeamServiceClient.GetAllCurrency()
                    };
                }
                else
                {
                    addNewUser = new AddNewUserToTeamViewModel
                    {
                        TeamList = await TeamServiceClient.GetTeamsToUser(Session["User"].ToString()),
                        UserList = await UserServiceClient.GetAllUser(),
                        CurrencyList = await TeamServiceClient.GetAllCurrency()
                    };
                }
            }
            return View(addNewUser);
        }

        public async Task<ActionResult> DeleteUser(TeamDetailsViewModel model)
        {
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteUser(long id)
        {
            try
            {
                await UserServiceClient.DeleteUserFromTeam(id);

                return RedirectToAction("TeamList", "Team");
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View();
        }
    }
}