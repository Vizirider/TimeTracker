using GalaSoft.MvvmLight.Ioc;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUi.Model.Client;
using WebUi.Model.Register;
using WebUi.Model.Team;
using WebUiServiceClient.Client;
using WebUiServiceClient.Team;

namespace WebUi.Controllers
{
    public class AdminClientController : Controller
    {
        private IClientServicClient _clientServicClient;
        private IClientServicClient ClientServicClient => _clientServicClient ?? (_clientServicClient = SimpleIoc.Default.GetInstance<IClientServicClient>());

        private ITeamServiceClient _teamServiceClient;
        private ITeamServiceClient TeamServiceClient => _teamServiceClient ?? (_teamServiceClient = SimpleIoc.Default.GetInstance<ITeamServiceClient>());

        // GET: AdminClient
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> ClientsList()
        {
            var clientList = new AddClientRequestView();

            try
            {
                clientList.ClientList = await ClientServicClient.GetAllClientList();
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View(clientList);
        }

        public async Task<ActionResult> DetailsClient(long id)
        {
            var detailsClient = new ClientDetailsViewModel();

            try
            {
                var result = await ClientServicClient.GetDetailsClientById(id);
                detailsClient.Id = result.Id;
                detailsClient.ClientName = result.ClientName;
                detailsClient.Website = result.Website;
                detailsClient.TeamName = result.TeamName;
                detailsClient.TeamId = result.TeamId;
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction("ClientsList");
            }

            return View(detailsClient);
        }

        
        public async Task<ActionResult> EditClient(long id)
        {
            var model = new ClientDetailsViewModel();

            try
            {
                var result = await ClientServicClient.GetDetailsClientById(id);
                model.Id = result.Id;
                model.ClientName = result.ClientName;
                model.Website = result.Website;
                model.TeamName = result.TeamName;
                model.TeamList = await TeamServiceClient.GetAllTeam();
               
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> EditClient(ClientDetailsViewModel model)
        {
            try
            {
                var result = await ClientServicClient.EditClient(model.Id, model.Website, model.TeamId, model.ClientName);
                model.TeamList = await TeamServiceClient.GetAllTeam();
                //return RedirectToAction("ClientsList");
                ViewBag.Message = "Done :)";
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View(model);
        }

        public async Task<ActionResult> DeleteClient(long id)
        {
            var model = new ClientDetailsViewModel();

            try
            {
                var result = await ClientServicClient.GetDetailsClientById(id);
                model.Id = result.Id;
                model.ClientName = result.ClientName;
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteClient(ClientDetailsViewModel model)
        {
            try
            {
                var result = await ClientServicClient.DeleteClient(model.Id);

                return RedirectToAction("ClientsList");
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
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
                model.Id = model.TeamDetailsList[0].Id;
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }

            return View(model);
        }
    }
}