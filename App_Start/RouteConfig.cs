using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StudentService
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
                   name: "pop",
                   url: "{Filter}/{pol}/{id}/{id2}",
                   defaults: new { controller = "Filter", action = "pol", id = UrlParameter.Optional, id2 = UrlParameter.Optional }
               );
            //routes.MapRoute(
            //      name: "pop1",
            //      url: "{Filter}/{Courses}/{id}",
            //      defaults: new { controller = "Filter", action = "pol", id = "" }
            //  );
        }
    }
}
