using GalaSoft.MvvmLight.Ioc;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web.Mvc;
using Server.Infrastructure.Dto;
using WebUi.Model.TimeRecord;
using WebUiServiceClient.TimeRecord;
using WebUiServiceClient.Todo;

namespace WebUi.Controllers
{
    public class TimeRecordController : Controller
    {
        private ITimeRecordServiceClient _timeRecordServiceClient;
        private ITimeRecordServiceClient TimeRecordServiceClient => _timeRecordServiceClient ?? (_timeRecordServiceClient = SimpleIoc.Default.GetInstance<ITimeRecordServiceClient>());

        private ITodoServiceClient _todoServiceClient;
        private ITodoServiceClient TodoServiceClient => _todoServiceClient ?? (_todoServiceClient = SimpleIoc.Default.GetInstance<ITodoServiceClient>());

        // GET: TimeRecord
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> AddTimeRecord()
        {
            var  model = new TimeRecordModel();
            try
            {
                model.TodoList = await TodoServiceClient.GetAllTodo();
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                model.TodoList = await TodoServiceClient.GetAllTodo();
            }
           
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AddTimeRecord(TimeRecordModel model)
        {
            try
            {
                var result =
                    await TimeRecordServiceClient.AddTimeRecord(model.Id, model.Comment, model.TimeInSeconds,
                        model.TodoId);

                ViewBag.Message = "Sikeres mentés :)";
                model.TodoList = await TodoServiceClient.GetAllTodo();

            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                model.TodoList = await TodoServiceClient.GetAllTodo();
            }
            return View(model);
        }

        public async Task<ActionResult> TimeRecordList()
        {
            var model = new TimeRecordModel();

            try
            {
                var result = await TimeRecordServiceClient.GetAllTimeRecords();
                model.TimeRecordList = await TimeRecordServiceClient.GetAllTimeRecords();

            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }

            return View(model);
        }

        public async Task<ActionResult> EditTimeRecord(long id)
        {
            var model = new TimeRecordModel();

            try
            {
                var result = await TimeRecordServiceClient.GeTimeRecordById(id);
                model.TodoList = await TodoServiceClient.GetAllTodo();

                model.Id = result.Id;
                model.Comment = result.Comment;
                model.TimeInSeconds = result.TimeInSeconds;
                model.TodoTitle = result.TodoTitle;
                model.TodoId = result.TodoId;
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                model.TodoList = await TodoServiceClient.GetAllTodo();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> EditTimeRecord(TimeRecordModel model)
        {
            try
            {
                var result = await TimeRecordServiceClient.EditTimeRecord(model.Id, model.Comment, model.TimeInSeconds, model.TodoId);

                return RedirectToAction("TimeRecordList");
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                model.TodoList = await TodoServiceClient.GetAllTodo();
            }
            return View(model);
        }

        public async Task<ActionResult> DeleteTimeRecord(long id)
        {
            var model =  new TimeRecordModel();

            try
            {
                var result = await TimeRecordServiceClient.GeTimeRecordById(id);

                model.Id = result.Id;
                model.Comment = result.Comment;
                model.TimeInSeconds = result.TimeInSeconds;
                model.TodoTitle = result.TodoTitle;
                model.TodoId = result.TodoId;
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteTimeRecord(TimeRecordModel model)
        {
            try
            {
                var result = await TimeRecordServiceClient.DeleteTimerecord(model.Id);

                return RedirectToAction("TimeRecordList");
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View(model);
        }
    }
}