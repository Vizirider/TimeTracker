using GalaSoft.MvvmLight.Ioc;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUi.Model.Client;
using WebUi.Model.Register;
using WebUiServiceClient.Client;

namespace WebUi.Controllers
{
    public class ClientController : Controller
    {
        private IClientServicClient _clientServicClient;
        private IClientServicClient ClientServicClient => _clientServicClient ?? (_clientServicClient = SimpleIoc.Default.GetInstance<IClientServicClient>());

        // GET
        public ActionResult Index()
        {
            return
            View();
        }

        public async Task<ActionResult> ClientsList()
        {
            var clientList = new AddClientRequestView();

            if (Session["User"] != null)
            {
                try
                {
                    clientList.ClientList = await ClientServicClient.GetAllClientByUser(Session["User"].ToString());
                }
                catch (Exception e)
                {
                    ViewBag.Message = e.Message;
                }
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
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }

            return View(detailsClient);
        }
    }
}