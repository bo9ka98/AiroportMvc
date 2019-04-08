using Airoport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Airoport.Controllers
{
    public class ClientsController : Controller
    {
        ClientContext db = new ClientContext();
        //TicketContext dbTicket = new TicketContext();

        // GET: Clients
        public ActionResult Index()
        {
            return View();
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {

                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult SearchClient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchClientResult(Man _man)
        {
            var allClients = db.Clients.Where(a => (a.Surname.Contains(_man.Surname) || a.Name.Contains(_man.Name))).ToList(); 
            if (allClients.Count <= 0)
            {
                return HttpNotFound(); 
            }
            return PartialView("SearchClientResult", allClients);
        }
    }
}