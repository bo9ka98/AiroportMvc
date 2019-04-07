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
        ClientContext db = ClientContext.getInstance();

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            IEnumerable<City> citiesDb = db.Cities;
            ViewBag.Cities = citiesDb;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}