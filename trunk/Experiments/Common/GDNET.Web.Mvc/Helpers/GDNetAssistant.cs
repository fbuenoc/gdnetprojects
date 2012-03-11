using System.Web.Mvc;

namespace GDNET.Web.Mvc.Helpers
{
    public static class GDNetAssistant
    {
        public static GDNetFactory GDNet(this HtmlHelper html)
        {
            return new GDNetFactory(html);
        }
    }
}
