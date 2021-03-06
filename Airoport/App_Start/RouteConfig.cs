﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Airoport
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default2",
                url: "{controller}/{action}/{config}",
                defaults: new { controller = "Client", action = "SearchClient" }
            );

            routes.MapRoute(name: "Default3",
                url: "{controller}/{action}/{id}/{config}",
                defaults: new { controller = "Home", action = "Index" });

            routes.MapRoute(name: "Default4",    
                url: "{controller}/{action}/{id}/{config}/{*catchall}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });



        }
    }
}
