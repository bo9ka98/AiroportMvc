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

        // GET: Clients
        public ActionResult Index()
        {
            return View();
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Регистрация нового пользователя";
            return View();
        }

        // POST: Clients/Create
        [HttpPost]
        public ActionResult Create(Client client)
        {
            try
            {
                if (client.Name != null && client.Surname != null) {
                    
                    db.Clients.Add(client);
                    db.SaveChanges();
                }
                else
                {
                    ViewBag.Message = "Неверные данные";
                    return View();
                }
                // TODO: Add insert logic here
                return RedirectToAction("SearchClient");
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
            var allClientsByName = db.Clients.Where(a => (a.Name.Contains(_man.Name))).ToList();
            var allClientsBySurname = db.Clients.Where(a => (a.Surname.Contains(_man.Surname))).ToList();
            var allClients = db.Clients.Where(a => (a.Surname.Contains(_man.Surname) || a.Name.Contains(_man.Name))).ToList();

            if (allClientsByName.Count + allClientsBySurname.Count <= 0)
            {
                return HttpNotFound(); 
            }

            ViewBag.allClientsByName = allClientsByName;
            ViewBag.allClientsBySurname = allClientsBySurname;

            return PartialView("SearchClientResult", allClients);
        }
    }
}