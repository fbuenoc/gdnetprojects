using System.Web.Mvc;

namespace WebFramework.Base.Helpers
{
    public static class WebFrameworkAssistant
    {
        public static WebFrameworkFactory WebFramework(this HtmlHelper html)
        {
            return new WebFrameworkFactory(html);
        }
    }
}
