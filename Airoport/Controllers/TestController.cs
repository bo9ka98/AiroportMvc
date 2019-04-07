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
        public ActionResult SearchClientView(Man _man)
        {

            return View();
        }
    }
}