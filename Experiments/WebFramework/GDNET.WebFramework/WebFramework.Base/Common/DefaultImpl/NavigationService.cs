using GDNET.Web.Helpers;
using WebFramework.Base.Common.Services;

namespace WebFramework.Base.Common.DefaultImpl
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