using GDNET.Web.Mvc.Services;
using WebFramework.Common.Common.DefaultImpl;
using WebFramework.Common.Common.Services;
using WebFramework.Common.Security;

namespace WebFramework.Common.Common
{
    public sealed class FrameworkServices
    {
        public static IValidationService Validation
        {
            get { return new ValidationService(); }
        }

        public static INavigationService Navigation
        {
            get { return new NavigationService(); }
        }

        public static IAuthorizationService Authorization
        {
            get { return new AuthorizationService(); }
        }
    }
}