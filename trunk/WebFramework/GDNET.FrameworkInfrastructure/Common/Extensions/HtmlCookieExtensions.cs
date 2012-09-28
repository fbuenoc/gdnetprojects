using System.Web.Mvc;
using GDNET.FrameworkInfrastructure.Services;

namespace GDNET.FrameworkInfrastructure.Common.Extensions
{
    public static class HtmlCookieExtensions
    {
        public static string GetUserCustomizedLanguageName(this HtmlHelper htmlHelper)
        {
            var userInfo = WebFrameworkServices.DataStored.GetUserCustomizedInfo();
            return userInfo.LanguageName;
        }
    }
}
