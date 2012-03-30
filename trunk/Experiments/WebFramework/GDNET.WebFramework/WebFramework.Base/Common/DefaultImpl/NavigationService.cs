using GDNET.Web.Helpers;
using WebFramework.Common.Common.Services;

namespace WebFramework.Common.Common.DefaultImpl
{
    public class NavigationService : INavigationService
    {
        public string AddReturnUrl(string currentUrl)
        {
            return NavigationAssistant.AddReturnUrl(currentUrl);
        }

        public string AddParameter(string currentUrl, string paramName, string paramValue)
        {
            return NavigationAssistant.AddParameter(currentUrl, paramName, paramValue);
        }
    }
}