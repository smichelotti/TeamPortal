using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;
using TeamPortal.Web.Models;

namespace TeamPortal.Web
{
    /*** Azure-specific ***/
    //TODO: Switch to Caching for Lookup data
    //TODO: Switch to Blob storage (from DB or file system?)
    //TODO: Switch to CDN for images
    //TODO: Switch to SQL Azure Federations (federate on Players TeamId)
    //TODO: ACS login associates to Team
    //TODO: Dummy data for Schedule?
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{teamId}/{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            Database.SetInitializer<TeamPortalWebContext>(new TeamPortalDbInitializer());
        }

        protected void Session_Start()
        {
            Session.Add("TeamId", 1);
        }
    }
}