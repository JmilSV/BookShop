using System;
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
                url: "{Basket}/{action}/{id}",
                defaults: new { controller = "Basket", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default3",
                url: "{Order}/{action}/{id}",
                defaults: new { controller = "Order", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
