using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using FluentSecurity;
using WebFramework.Common.Security;
using WebFramework.Common.Widgets;
using WebFramework.Domain;

namespace WebFramework
{
    public class MvcApplication : HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleSecurityAttribute());
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        }

        protected void Application_Start()
        {
            ViewEngines.Engines.Clear();

            Bootstrapper.SetupFluentSecurity();
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

    }
}