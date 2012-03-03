using WebFramework.Common.DefaultImpl;
using WebFramework.Common.Services;

namespace WebFramework.Common
{
    public sealed class FrameworkServices
    {
        public static IValidationService Validation
        {
            get { return new ValidationService(); }
        }
    }
}