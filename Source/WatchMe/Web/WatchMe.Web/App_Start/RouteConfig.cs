﻿using System.Web.Mvc;
using System.Web.Routing;

namespace WatchMe.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "CategoryDetails",
                url: "Categories/{id}",
                defaults: new { controller = "Categories", action = "Details" },
                namespaces: new[] { "WatchMe.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Wishlist",
                url: "Wishlist",
                defaults: new { controller = "Users", action = "Wishlist" },
                namespaces: new[] { "WatchMe.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "WatchMe.Web.Controllers" }
            );
        }
    }
}