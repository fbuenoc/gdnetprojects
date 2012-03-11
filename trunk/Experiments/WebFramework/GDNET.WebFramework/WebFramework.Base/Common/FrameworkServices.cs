using WebFramework.Base.Common.DefaultImpl;
using WebFramework.Base.Common.Services;

namespace WebFramework.Base.Common
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