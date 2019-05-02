using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AjaxPractice
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Contacts", action = "Index", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
               name: "LocalizedDefault",
               url: "{lang}/{controller}/{action}/{id}",
               defaults: new { controller = "Contacts", action = "Index", id = UrlParameter.Optional },
               constraints: new { lang = "az|ru|en" }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Contacts", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
