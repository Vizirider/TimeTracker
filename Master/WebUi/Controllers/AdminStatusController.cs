using GalaSoft.MvvmLight.Ioc;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUi.Model.Status;
using WebUiServiceClient.Admin;
using WebUiServiceClient.User;

namespace WebUi.Controllers
{
    public class AdminStatusController : Controller
    {

        private IAdminServiceClient _adminServiceClient;
        private IAdminServiceClient AdminServiceClient => _adminServiceClient ?? (_adminServiceClient = SimpleIoc.Default.GetInstance<IAdminServiceClient>());

        private IUserServiceClient _userServiceClient;

        private IUserServiceClient UserServiceClient =>
            _userServiceClient ?? (_userServiceClient = SimpleIoc.Default.GetInstance<IUserServiceClient>());

        // GET: AdminStatus
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> StatusList()
        {
            var status = new Status();

            try
            {
                status.StatusList = await UserServiceClient.GetAllStatus();
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }

            return View(status);
        }

        public async Task<ActionResult> AddNewStatus()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddNewStatus(Status model)
        {
            try
            {
                await AdminServiceClient.AddNewStatus(model.Name, model.State);

                return RedirectToAction("StatusList");
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }

            return View();
        }

        public async Task<ActionResult> EditStatus(long id)
        {
            Status status = new Status();
            try
            {
                var result = await AdminServiceClient.GetStatusById(id);
                status.Id = result.Id;
                status.Name = result.Name;
                status.State = result.StateTypeId;
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }

            return View(status);
        }

        [HttpPost]
        public async Task<ActionResult> EditStatus(Status request)
        {
            try
            {
                await AdminServiceClient.EditStatus(request.Id, request.Name, request.State);

                return RedirectToAction("StatusList");
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View();
        }

        public async Task<ActionResult> DeleteStatus(long id)
        {
            var model = new Status();

            try
            {
                var result = await AdminServiceClient.GetStatusById(id);
                model.Name = result.Name;
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteStatus( Status model)
        {
            try
            {
                await AdminServiceClient.DeleteStatus(model.Id);
                return RedirectToAction("StatusList");
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }

            return View(model);
        }
    }
}