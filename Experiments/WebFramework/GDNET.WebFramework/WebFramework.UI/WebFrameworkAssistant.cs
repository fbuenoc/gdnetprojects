using System.Web.Mvc;
using WebFramework.Common.Security;
using WebFramework.UI.Common;

namespace WebFramework.UI
{
    public static class WebFrameworkAssistant
    {
        public static WebFrameworkFactory WebFramework(this HtmlHelper html)
        {
            return new WebFrameworkFactory(html);
        }

        public static SecurityAssistant FrameworkSecurity(this HtmlHelper html)
        {
            return new SecurityAssistant();
        }
    }
}
