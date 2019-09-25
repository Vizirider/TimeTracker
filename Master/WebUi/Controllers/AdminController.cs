using System;
using GalaSoft.MvvmLight.Ioc;
using System.Threading.Tasks;
using System.Web.Mvc;
using Server.Infrastructure.Dto.Requests.User;
using WebUi.Model.User;
using WebUiServiceClient.User;
using DataAccessLayer;

namespace WebUi.Controllers
{
    public class AdminController : Controller
    {
        private IUserServiceClient _userServiceClient;
        private IUserServiceClient UserServiceClient => _userServiceClient ?? (_userServiceClient = SimpleIoc.Default.GetInstance<IUserServiceClient>());

        // GET
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Info()
        {
            var user = new UserViewModel();

            if (Session["User"] != null)
            {
                try
                {
                    var result = await UserServiceClient.GetUserByEmail(Session["User"].ToString());

                    user.Name = result.Name;
                    user.Email = result.Email;
                    user.Phone = result.Phone;
                    user.RoleName = Enum.GetName(typeof(RoleTypeEnum), result.RoleId).ToString();
                }
                catch (Exception e)
                {
                    ViewBag.Message = e.Message;
                }
            }

            return View(user);
        }

        public async Task<ActionResult> EditUser()
        {
            var user = new UserViewModel();

            if (Session["User"] != null)
            {
                try
                {
                    var result = await UserServiceClient.GetUserByEmail(Session["User"].ToString());

                    user.Id = result.Id;
                    user.Name = result.Name;
                    user.Email = result.Email;
                    user.Phone = result.Phone;
                    user.RoleName = result.RoleName;
                }
                catch (Exception e)
                {
                    ViewBag.Message = e.Message;
                }
            }

            return View(user);
        }

        [HttpPost]
        public async Task<ActionResult> EditUser(UserViewModel model)
        {
            var request = new AddUserRequest
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                Password = model.Password
            };

            try
            {
                var result = await UserServiceClient.EditUser(request);

                ViewBag.Message = "Done :)";
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }

            return View();
        }
    }
}
