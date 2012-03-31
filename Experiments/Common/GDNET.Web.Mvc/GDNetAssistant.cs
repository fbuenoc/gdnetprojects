using System.Web.Mvc;
using GDNET.Web.Mvc.Helpers;

namespace GDNET.Web.Mvc
{
    public static class GDNetAssistant
    {
        public static GDNetFactory GDNet(this HtmlHelper html)
        {
            return new GDNetFactory(html);
        }
    }
}
