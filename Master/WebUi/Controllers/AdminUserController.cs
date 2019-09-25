using GalaSoft.MvvmLight.Ioc;
using Server.Infrastructure.Dto.Requests.User;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUi.Model.User;
using WebUiServiceClient.Role;
using WebUiServiceClient.User;

namespace WebUi.Controllers
{
    public class AdminUserController : Controller
    {
        private IUserServiceClient _userServiceClient;
        private IUserServiceClient UserServiceClient => _userServiceClient ?? (_userServiceClient = SimpleIoc.Default.GetInstance<IUserServiceClient>());

        private IRoleServiceClient _roleServicClient;
        private IRoleServiceClient RoleServiceClient => _roleServicClient ?? (_roleServicClient = SimpleIoc.Default.GetInstance<IRoleServiceClient>());

        // GET: AdminUser
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> UserList()
        {
            var user = new UserViewModel();

            try
            {
                user.UserList = await UserServiceClient.GetAllUser();
                
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }

            return View(user);
        }

        public async Task<ActionResult> EditUser(long id)
        {
            var model = new UserViewModel();

            try
            {
                var result = await UserServiceClient.GetUserById(id);
                model.RoleList = await RoleServiceClient.GetAllRole();

                model.Id = result.Id;
                model.Name = result.Name;
                model.Email = result.Email;
                model.Phone = result.Phone;
                model.RoleId = result.RoleId;
                model.RoleName = result.RoleName;
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> EditUser(UserViewModel model)
        {

            var user = new AddUserRequest
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                RoleId = model.RoleId,
                Password = model.Password
            };

            try
            {
                var result = await UserServiceClient.EditUser(user);

                return RedirectToAction("UserList");
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View(model);
        }

        public async Task<ActionResult> DeleteUser(long id)
        {
            var user = new UserViewModel();

            try
            {
                var result = await UserServiceClient.GetUserById(id);
                user.Id = result.Id;
                user.Name = result.Name;
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View(user);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteUser(UserViewModel model)
        {
            try
            {
                var result = await UserServiceClient.DeleteUser(model.Id);

                return RedirectToAction("UserList");
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }

            return View(model);
        }
    }
}