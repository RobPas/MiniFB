using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MiniFB.Models;
using Microsoft.AspNet.SignalR;

namespace MiniFB
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

           //RouteTable.Routes.MapConnection<ChatConnection>("chat", "chat/{*operation}");

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}