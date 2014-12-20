﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TN.Web
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
               name: "BlogTitle",
               url: "Blog/{UrlTitle}",
               defaults: new { controller = "Blog", action = "Post"});


            routes.MapRoute(
                name: "Blog",
                url: "Blog",
                defaults: new {controller = "Blog", action = "Index", id = UrlParameter.Optional});
        }
    }
}
