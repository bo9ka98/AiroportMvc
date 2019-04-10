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
            //ViewData["Cities"]
            ViewBag.Cities = service.GetCityContext().Cities;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Ticket ticket)
        {
                ticket.DateBuy = DateTime.Now;
            if (service.AddElementInTicketContext(ticket))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View(service.FindTicketById(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, Ticket ticket)
        {
            if(service.RemoveElementOfTicketContext(ticket))
            { 
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
