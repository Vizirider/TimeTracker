using GalaSoft.MvvmLight.Ioc;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUi.Model.Permission;
using WebUiServiceClient.Permission;

namespace WebUi.Controllers
{
    public class AdminPermissionController : Controller
    {
        private IPermissionServiceClient _permissionServiceClient;
        private IPermissionServiceClient PermissionServiceClient => _permissionServiceClient ?? (_permissionServiceClient = SimpleIoc.Default.GetInstance<IPermissionServiceClient>());

        // GET: AdminPermission
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> PermissionList()
        {
            var model = new PermissionModel();

            try
            {
                model.PermissionList = await PermissionServiceClient.GetAllPermission();
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View(model);
        }

        public async Task<ActionResult> AddNewPermission()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddNewPermission(PermissionModel model)
        {
            try
            {
                await PermissionServiceClient.AddPermission(model.Id, model.Key, model.PermissionTypeId);

                return RedirectToAction("PermissionList");
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View();
        }

        public async Task<ActionResult> EditPermission(long id)
        {
            var permission = new PermissionModel();

            try
            {
                var result = await PermissionServiceClient.GetPermissionById(id);
                permission.Id = result.Id;
                permission.Key = result.Key;
                permission.PermissionTypeId = result.PermissionTypeId;

            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }

            return View(permission);
        }

        [HttpPost]
        public async Task<ActionResult> EditPermission(PermissionModel model)
        {
            try
            {
                await PermissionServiceClient.EditPermission(model.Id, model.Key, model.PermissionTypeId);

                return RedirectToAction("PermissionList");
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View();
        }

        public async Task<ActionResult> DeletePermission(long id)
        {
            var model =  new PermissionModel();
            try
            {
                var result = await PermissionServiceClient.GetPermissionById(id);
                model.Id = result.Id;
                model.Key = result.Key;
                model.PermissionTypeId = result.PermissionTypeId;
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> DeletePermission(PermissionModel model)
        {
            try
            {
                await PermissionServiceClient.DeletePermission(model.Id);

                return RedirectToAction("PermissionList");
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View(model);
        }
    }
}