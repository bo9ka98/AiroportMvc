using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Airoport.Models;

namespace Airoport.Controllers
{
    public class TicketController : Controller
    {
        AService service = AService.GetInstance();

        public ActionResult Index()
        {
            return View(service.GetEnumerableForTicketContext());
        }

        public ActionResult Details(int id)
        {
            return View(service.FindTicketById(id));
        }


        public ActionResult Create(int id)
        {
            ViewBag.ClientId = id;
            ViewBag.Client = service.FindClientById(id);
            ViewBag.Cities = service.GetEnumerableForCityContext();
            return View("Create");
        }
        [HttpPost]
        public ActionResult Create(Ticket ticket)
        {
            ticket.DateBuy = DateTime.Now;
            if (!ModelState.IsValid)
            {
                SetDataForEdit();
                return View("Create",ticket);
            }
            if (ticket.ArrivalCityId == ticket.DepartCityId)
            {
                SetDataForEdit();
                ViewBag.Message = "Ошибка - для таких трипов билет не нужен";
                return View("Create", ticket);
            }
            if (!service.AddTicketInContext(ticket))
            {
                SetDataForEdit();
                ViewBag.Message = "Ошибка подключения, звонить фиксикам";
                return View("Create", ticket);
            }
            return RedirectToAction("Index", "Home");
            void SetDataForEdit()
            {
                ViewBag.ClientId = ticket.ClientId;
                ViewBag.Client = service.FindClientById(ticket.ClientId);
                ViewBag.Cities = service.GetEnumerableForCityContext();
            }
        }


        public ActionResult Edit(int id)
        {
            return View(service.FindTicketById(id));
        }
        [HttpGet]
        public ActionResult EditClientList(int id, string config)
        {
            ViewBag.Client = service.FindClientById(id).ToString();

            if (config == "registr")
            {
                return View(service.FindTicketListByClientId(id));
            }

            if (config == "return")
            {
                return View("DeleteClientList",service.FindTicketListByClientId(id));
            }

            throw new Exception("config имеет необычное значение");
        }

        [HttpPost]
        //[Bind(Include = "Registered")]
        public ActionResult Edit(int id,  Ticket ticket)
        {
            if (service.EditTicketRegisteredInContext(ticket))
            {
                return RedirectToAction("Index", "Home");
            }

            return View(ticket);
        }

        


        [HttpPost]
        //[Bind(Include = "Registered")]
        public ActionResult EditClientList(int id, Ticket ticket)
        {
            if (service.EditTicketRegisteredInContext(ticket))
            {
                return RedirectToAction("Index", "Home");
            }

            return View(ticket);
        }

        public ActionResult Delete(int id)
        {
            return View(service.FindTicketById(id));
        }
        public ActionResult DeleteList(int id)
        {
            return View(service.FindTicketById(id));
        }
        [HttpPost]
        public ActionResult Delete(int id, Ticket ticket)
        {
            if(service.RemoveTicketOfContext(ticket))
            { 

                return RedirectToAction("Index", "Home" );
            }
            else
            {
                return View();
            }
        }
    }
}
