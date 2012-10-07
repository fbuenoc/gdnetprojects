using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using GDNET.Business.Services;
using GDNET.Data;
using GDNET.Data.Base;
using GDNET.FrameworkInfrastructure.Common.Handlers;
using log4net;
using log4net.Config;

namespace GDNET.FrameworkInfrastructure.Common.Base
{
    public class GDNETHttpApplication : HttpApplication
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(GDNETHttpApplication));

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
                    aRoute.Url = "{" + FrameworkConstants.LanguageRouteKey + "}/" + aRoute.Url;

                    if (aRoute.Defaults == null)
                    {
                        aRoute.Defaults = new RouteValueDictionary();
                    }
                    aRoute.Defaults.Add(FrameworkConstants.LanguageRouteKey, "vi");

                    if (aRoute.Constraints == null)
                    {
                        aRoute.Constraints = new RouteValueDictionary();
                    }
                    aRoute.Constraints.Add(FrameworkConstants.LanguageRouteKey, new LanguageRouteConstraint());
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

            // Configu Log4Net
            XmlConfigurator.Configure();
            logger.Info("Application starting...");
        }
    }
}
