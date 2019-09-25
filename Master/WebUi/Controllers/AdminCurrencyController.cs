using GalaSoft.MvvmLight.Ioc;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUi.Model.Currency;
using WebUiServiceClient.Admin;

namespace WebUi.Controllers
{
    public class AdminCurrencyController : Controller
    {
        private IAdminServiceClient _adminServiceClient;
        private IAdminServiceClient AdminServiceClient => _adminServiceClient ?? (_adminServiceClient = SimpleIoc.Default.GetInstance<IAdminServiceClient>());

        // GET: AdminCurrency
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> CurrencyList()
        {
            var model = new CurrencyModel();
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

        public async Task<ActionResult> EditCurrency(long id)
        {
            var model = new CurrencyModel();

            try
            {
                var result = await AdminServiceClient.GetCurrencyById(id);

                model.Id = result.Id;
                model.Code = result.Code;
                model.IsDefault = (bool)result.IsDefault;
                model.PriceToDefault = result.PriceToDefault;
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> EditCurrency(CurrencyModel model)
        {
            try
            {
                await AdminServiceClient.EditCurrency(model.Id, model.Code, model.IsDefault, model.PriceToDefault);

                return RedirectToAction("CurrencyList");
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View(model);
        }

        public async Task<ActionResult> AddNewCurrency()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddNewCurrency(CurrencyModel model)
        {
            try
            {
                await AdminServiceClient.AddnewCurrency(model.Code, model.IsDefault, model.PriceToDefault);
                return RedirectToAction("CurrencyList");
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View();
        }

        public async Task<ActionResult> DeleteCurrency(long id)
        {
            var model = new CurrencyModel();
            try
            {
                var result = await AdminServiceClient.GetCurrencyById(id);
                model.Id = result.Id;
                model.Code = result.Code;
                model.IsDefault = (bool)result.IsDefault;
                model.PriceToDefault = result.PriceToDefault;
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteCurrency(CurrencyModel model)
        {
            try
            {
                await AdminServiceClient.DeleteCurrency(model.Id);

                return RedirectToAction("CurrencyList");
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View();
        }
    }
}