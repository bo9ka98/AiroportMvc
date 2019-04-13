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
        readonly int ERR = -1;
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
        [HttpGet]
        public ActionResult CreateMan(Man man)
        {
            ViewBag.Title = "Регистрация нового пользователя";
            return View(man);
        }
        [HttpPost]
        public ActionResult Create(Client client)
        {
            if (client.Name == null && client.Surname == null) {
                ViewBag.Message = "Неверные данные";
                return View();
            }

            if (!service.AddElementInClientContext(client))
            {
                ViewBag.Message = "Ошибка контекста";
                return View();
                
            }


            return RedirectToAction("Create", "Ticket", (int)client.Id);
        }


        [Route("{config}")]
        public ActionResult SearchClient(string config)
        {
            ViewBag.config = config;
            ViewBag.Title = "Поиск клиента";
            return View();
        }
        [HttpPost]
        public ActionResult SearchClientResult(string config, Man _man)
        {
            var allClients = service.ClientContext.Clients.Where(a => (a.Surname.Contains(_man.Surname) && a.Name.Contains(_man.Name))).ToList();

            if (allClients.Count == 0)
            {
                ViewBag.Err = "Клиент не найден";
            } 
            else
            {
                ViewBag.Err = "";
            }

            if (config == "")
            {
                return PartialView("SearchClientResult", allClients);
            }

            if (config == "registr")
            {
                ViewData["config"] = config;
                return PartialView("SearchClientRegistr", allClients);
            }

            if (config == "return")
            {
                ViewData["config"] = config;
                return PartialView("SearchClientReturn", allClients);
            }

            throw new Exception("config имеет необычное значение");
        }

    }
}