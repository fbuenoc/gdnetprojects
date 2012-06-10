using System.Collections.Generic;
using System.Web;
using FluentSecurity;

namespace WebFramework.Common.Security
{
    public class Bootstrapper
    {
        public static ISecurityConfiguration SetupFluentSecurity()
        {
            SecurityConfigurator.Configure(configuration =>
            {
                configuration.IgnoreMissingConfiguration();
                configuration.GetAuthenticationStatusFrom(() => HttpContext.Current.User.Identity.IsAuthenticated);
                configuration.GetRolesFrom(() => GetRolesForUser());

                configuration.ForAllControllersInAssemblyImplementedType<IRequiredAuthenticatedController>().DenyAnonymousAccess();
                configuration.ForAllControllersInAssemblyImplementedType<IRequiredAdministratorController>().RequireRole("Administrator");
            });

            return SecurityConfiguration.Current;
        }

        private static IEnumerable<object> GetRolesForUser()
        {
            List<object> listeOfRoles = new List<object>();

            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                listeOfRoles.Add("Administrator");
            }

            return listeOfRoles;
        }
    }
}