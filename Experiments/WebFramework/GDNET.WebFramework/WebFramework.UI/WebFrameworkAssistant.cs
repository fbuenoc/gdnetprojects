using System.Web.Mvc;
using WebFramework.UI.Helpers;

namespace WebFramework.UI
{
    public static class WebFrameworkAssistant
    {
        public static WebFrameworkFactory WebFramework(this HtmlHelper html)
        {
            return new WebFrameworkFactory(html);
        }
    }
}
