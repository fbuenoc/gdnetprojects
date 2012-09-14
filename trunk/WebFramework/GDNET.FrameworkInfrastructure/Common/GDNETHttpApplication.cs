using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using GDNET.Business.Services;
using GDNET.Data;
using GDNET.Data.Base;
using GDNET.FrameworkInfrastructure.Common.Base;
using GDNET.FrameworkInfrastructure.Common.Handlers;

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

            foreach (Route aRoute in routes)
            {
                if (!(aRoute.RouteHandler is NormalMvcRouteHandler))
                {
                    aRoute.RouteHandler = new MultilingualMvcRouteHandler();
                    aRoute.Url = "{language}/" + aRoute.Url;

                    if (aRoute.Defaults == null)
                    {
                        aRoute.Defaults = new RouteValueDictionary();
                    }
                    aRoute.Defaults.Add("language", "vi");

                    if (aRoute.Constraints == null)
                    {
                        aRoute.Constraints = new RouteValueDictionary();
                    }
                    aRoute.Constraints.Add("language", new LanguageConstraint());
                }
            }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            var servicesManager = new ServicesManager();
            var repositoryStrategy = new DataRepositoryStrategy(WebNHibernateSessionManager.Instance);
            var repositories = new DataRepositories(repositoryStrategy);
        }
    }
}
