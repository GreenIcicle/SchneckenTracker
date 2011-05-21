using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null, "User/Logout", new { controller = "User", action = "Logout" });
            routes.MapRoute(null, "User/Login", new { controller = "User", action = "Login" });
            routes.MapRoute(null, "User/Authenticate", new { controller = "User", action = "Authenticate" });
            routes.MapRoute(null, "TrackLocation", new { controller = "Tracking", action = "TrackLocation" });
            routes.MapRoute(null, "", new { controller = "Home", action = "Home" });
        }


        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}