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

        // GET: Ticket
        public ActionResult Index()
        {
            return View(service.GetEnumerableForTicketContext());
        }

        // GET: Ticket/Details/5
        public ActionResult Details(int id)
        {
            Ticket ticket = service.GetTicketContext().Tickets.Where(a => a.Id == id).First();
            return View(ticket);
        }

        // GET: Ticket/Create
        public ActionResult Create(int id)
        {
            ViewBag.ClientId = id;
            return View(service.GetSelectListForCities());
        }

        // POST: Ticket/Create
        [HttpPost]
        public ActionResult Create(Ticket ticket)
        {
            ticket.DateBy = DateTime.Now;
            if (service.AddElementInTicketContext(ticket))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: Ticket/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ticket/Edit/5
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

        // GET: Ticket/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ticket/Delete/5
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
