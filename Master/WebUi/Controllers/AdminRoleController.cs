using GalaSoft.MvvmLight.Ioc;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUi.Model.Role;
using WebUiServiceClient.Role;

namespace WebUi.Controllers
{
    public class AdminRoleController : Controller
    {
        private IRoleServiceClient _roleServicClient;
        private IRoleServiceClient RoleServiceClient => _roleServicClient ?? (_roleServicClient = SimpleIoc.Default.GetInstance<IRoleServiceClient>());

        // GET: AdminRole
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> RoleList()
        {
            var model = new RoleModel();

            try
            {
                model.RoleList = await RoleServiceClient.GetAllRole();
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View(model);
        }

        public async Task<ActionResult> AddRole()
        {

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddRole(RoleModel model)
        {
            try
            {
                await RoleServiceClient.AddRole(model.Key, model.RoleTypeId);

                return RedirectToAction("RoleList");
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View();
        }
            

        public async Task<ActionResult> EditRole(long id)
        {
            RoleModel model = new RoleModel();

            try
            {
                var result = await RoleServiceClient.GetRoleById(id);

                model.Id = result.Id;
                model.Key = result.Key;
                model.RoleTypeId = result.RoleTypeId;
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> EditRole(RoleModel model)
        {
            try
            {
                await RoleServiceClient.EditRole(model.Id, model.Key, model.RoleTypeId);

                return RedirectToAction("RoleList");
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View();
        }

        public async Task<ActionResult> DeleteRole(long id)
        {
            RoleModel model = new RoleModel();

            try
            {
                var result = await RoleServiceClient.GetRoleById(id);

                model.Id = result.Id;
                model.Key = result.Key;
                model.RoleTypeId = result.RoleTypeId;
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteRole(RoleModel model)
        {
            try
            {
                await RoleServiceClient.DeleteRole(model.Id);

                return RedirectToAction("RoleList");
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View(model);
        }
    }
}