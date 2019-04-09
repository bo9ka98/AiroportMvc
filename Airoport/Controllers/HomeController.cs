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
        CityContext dbCity = new CityContext();
        ClientContext dbClient = new ClientContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.MessageCity = "Возможные города для путишествия";
            IEnumerable<City> citiesDb = dbCity.Cities;
            ViewBag.Cities = citiesDb;
            ViewBag.MassageClient = "Возможные клиенты";
            IEnumerable<Client> clientDb = dbClient.Clients;
            ViewBag.Clients = clientDb;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}