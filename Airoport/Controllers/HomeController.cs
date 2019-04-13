using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Airoport.Models;

namespace Airoport.Controllers
{
    public class HomeController : Controller
    {
        AService service = AService.GetInstance();

        public ActionResult Index()
        {
            ViewBag.Count = Client.countClients;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.MessageCity = "Возможные города для путишествия";
            ViewBag.Cities = service.GetEnumerableForCityContext();
            ViewBag.MassageClient = "Возможные клиенты";
            ViewBag.Clients = service.GetEnumerableForClientContext();
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Виталий - \"Я у мамы программист\"";
            return View();
        }

        public ActionResult ExceptionLogger()
        {
            return View(service.dbLogger.ExceptionDetails);
        }

        public ActionResult ExeptionDelete(int id)
        {
            ExceptionDetail exception = service.dbLogger.ExceptionDetails.Find(id);
            if (exception == null)
            {
                ViewBag.Title = "Err";
                return View("ExceptionLogger");
            }
            service.dbLogger.ExceptionDetails.Remove(exception);
            service.dbLogger.SaveChanges();

            return View("ExceptionLogger", service.dbLogger.ExceptionDetails);
        }
    }
}