using WebFramework.Common.Common.DefaultImpl;
using WebFramework.Common.Common.Services;

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
    }
}