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
        AService service = AService.GetInstance();

        public ActionResult Index()
        {
            return View(service.GetEnumerableForClientContext());
        }

        public ActionResult Create()
        {
            ViewBag.Title = "Регистрация нового пользователя";
            return View();
        }
        [HttpPost]
        public ActionResult Create(Client client)
        {
            if (client.Name != null && client.Surname != null) {
                    if (service.AddElementInClientContext(client))
                    {
                        return RedirectToAction("SearchClient");
                    }
                    else
                    {
                        ViewBag.Message = "Ошибка контекста";
                        return View();
                    }
                }
                else
                {
                    ViewBag.Message = "Неверные данные";
                    return View();
                }
        }

        [Route("{config}")]
        public ActionResult SearchClient(string config)
        {
            ViewBag.config = config;
            return View();
        }

        [HttpPost]
        public ActionResult SearchClientResult(string config, Man _man)
        {
            var allClientsByName = service.ClientContext.Clients.Where(a => (a.Name.Contains(_man.Name))).ToList();
            var allClientsBySurname = service.ClientContext.Clients.Where(a => (a.Surname.Contains(_man.Surname))).ToList();
            var allClients = service.ClientContext.Clients.Where(a => (a.Surname.Contains(_man.Surname) || a.Name.Contains(_man.Name))).ToList();

            if (allClientsByName.Count + allClientsBySurname.Count <= 0)
            {
                return HttpNotFound(); 
            } 

            ViewBag.allClientsByName = allClientsByName;
            ViewBag.allClientsBySurname = allClientsBySurname;

            if (config == "")
            {
                return PartialView("SearchClientResult", allClients);
            }

            if (config == "registr")
            {
                return PartialView("SearchClientRegistr", allClients);
            }

            if (config == "return")
            {
                return PartialView("SearchClientReturn", allClients);
            }

            throw new Exception("config имеет необычное значение");
        }


        public ActionResult RegistrembarkationClient()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegistrembarkationClient(Man _man)
        {
            return View();
        }

    }
}