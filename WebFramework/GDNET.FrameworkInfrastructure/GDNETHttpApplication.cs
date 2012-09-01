using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using GDNET.Business.Services;
using GDNET.Data;
using GDNET.Data.Base;

namespace GDNET.FrameworkInfrastructure
{
    public class GDNETHttpApplication : HttpApplication
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
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            var sessionStrategy = new DataSessionStrategy(WebNHibernateSessionManager.Instance);
            var repositories = new DataRepositories(sessionStrategy);
            var servicesManager = new ServicesManager();
        }
    }
}
