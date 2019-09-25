using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUi.Model.Language;

namespace WebUi.Controllers
{
    public class LanguageController : Controller
    {
        protected override System.IAsyncResult BeginExecuteCore(System.AsyncCallback callback, object state)
        {
            string lang = null;
            HttpCookie langCookie = Request.Cookies["culture"];
            if (langCookie != null)
            {
                lang = langCookie.Value;
            }
            else
            {
                var userLanguage = Request.UserLanguages;
                var userLang = userLanguage != null ? userLanguage[0] : "";
                if (userLang != "")
                {
                    lang = userLang;
                }
                else
                {
                    lang = Language.GetDefaultLanguage();
                }
            }
            new Language().SetLanguage(lang);
            return base.BeginExecuteCore(callback, state);
        }
        // GET: Language
        public ActionResult Index()
        {
            return View();
        }
    }
}