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

                configuration.ForAllControllersInAssemblyImplementedType<IRequiredAuthenticatedController>().DenyAnonymousAccess();
            });

            return SecurityConfiguration.Current;
        }
    }
}