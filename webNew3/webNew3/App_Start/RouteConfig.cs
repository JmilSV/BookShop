﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using webNew3.Models;

namespace webNew3
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional}
            );
            routes.MapRoute(
                name: "Default2",
                url: "{Cart}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default3",
                url: "{Order}/{action}/{id}",
                defaults: new { action = "Create", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default4",
                url: "{User}/{action}/{id}",
                defaults: new { controller = "User", action = "Create", id = UrlParameter.Optional }
            );
        }
    }
}
