using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Airoport.Models;

namespace Airoport.Controllers
{
    public class TestController : Controller
    {
        ClientContext db = ClientContext.getInstance();

        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        // GET: Test
        public ActionResult SearchClient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PartialClientInSearch(Man _man)
        {
            //var allClient = db.Clients.Where(a => a.Surname.Contains(_man.Surname)).ToList();
            var allClient = db.Cities.Where(a => a.Name.Contains(_man.Surname)).ToList(); //Тест сравнения фамилии и города =)
            if (allClient.Count <= 0)
            {
                return HttpNotFound();
            }
            //IEnumerator<Client> allClientList = allClient.GetEnumerator();
            return PartialView(allClient);
        }
    }
}