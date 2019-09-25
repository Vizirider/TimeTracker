using GalaSoft.MvvmLight.Ioc;
using Server.Infrastructure.Dto;
using System;
using System.Net;
using System.Net.Mail;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUi.Model.Login;
using WebUiServiceClient.User;
using System.Security.Claims;

namespace WebUi.Controllers
{
    public class LoginController : Controller
    {
        private IUserServiceClient _userServiceClient;

        private IUserServiceClient UserServiceClient => _userServiceClient ?? (_userServiceClient = SimpleIoc.Default.GetInstance<IUserServiceClient>());

        // GET: Login
        public  ActionResult Index()
        {
            var model = new LoginViewModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(LoginViewModel loginRequest)
        {
            var role = new RoleDto();
           
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await UserServiceClient.Login(loginRequest.Email, loginRequest.Password);
                    Session["User"] = user.Email;

                    role = await UserServiceClient.GetRoleTypeId(user.Email);
                    Session["Role"] = role.Key;

                    if (role.Key == "Admin")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else if (role.Key == "User")
                    {
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Client");
                    }
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Sikertelen Belépés!!";
                }
            }
      
            return View();
        }

        public ActionResult Logout()
        {
            Session.Remove("User");
            Session.Remove("Role");

            return RedirectToAction("Index");
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel forgotPasswordViewModel)
        {
            if (forgotPasswordViewModel.Email != null)
            {
                try
                {
                    await UserServiceClient.Forgot(forgotPasswordViewModel.Email);
                    string token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
                    // todo : saját mail címre küldje a levelet
                    SendResetLinkEmail(forgotPasswordViewModel.Email);
                    ViewBag.Message = "Jelszó visszaállító link elküdve!";
                }
                catch (Exception e)
                {
                    ViewBag.Error = e.Message;
                }
            }
            
            return View();
        }
        public ActionResult ResetPassword()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public  ActionResult ResetPassword(ForgotPasswordViewModel forgotPassword)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UserServiceClient.ResetPassword(forgotPassword.Email, forgotPassword.Password,forgotPassword.Token);
                    ViewBag.Message = "A jelszó visszaállítás sikeresen megtörtént :) ";
                }
                catch (Exception e)
                {
                    ViewBag.Error = e.Message;
                }
            }

            return View();
        }

        [ValidateAntiForgeryToken]
        [NonAction]
        public void SendResetLinkEmail(string email)
        {
            // todo: admin email 
            var token = Guid.NewGuid();
            var tokenExpiration = TimeSpan.FromDays(1);

            var fromEmail = new MailAddress("info.creativeteams@gmail.com", "TimeTracker");
            var toEmail = new MailAddress(email);
            var fromEmailPassword = "KD0223kd#";
    
            string uri = "Login/ResetPassword";

            string link = @"http://localhost:56359/"+uri+"/"+token;
            string subject = "Reset Password";
            string body = "Hi,<br/><br/>We got request for reset your account password. Please click on the below link to reset your password" +
                          "<br/><br/><a href=" + link + ">Reset Password link</a>";

            try
            {
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
                };

                using (var message = new MailMessage(fromEmail, toEmail)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })
                    smtp.Send(message);
            }
            catch (Exception e)
            {
                throw new FaultException("Nem sikerült az emailt elküldeni!");
            }
        }
    }
}