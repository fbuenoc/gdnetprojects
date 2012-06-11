using System.Web.Mvc;
using WebFramework.Common.Security;

namespace WebFramework.UI
{
    public static class WebFrameworkAssistant
    {
        public static WebFrameworkFactory WebFramework(this HtmlHelper html)
        {
            return new WebFrameworkFactory(html);
        }

        public static AuthorizationService FrameworkSecurity(this HtmlHelper html)
        {
            return new AuthorizationService();
        }
    }
}
