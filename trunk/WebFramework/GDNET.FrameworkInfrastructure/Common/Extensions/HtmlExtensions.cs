using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace GDNET.FrameworkInfrastructure.Common.Extensions
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString ActionLinkWithId(this HtmlHelper htmlHelper, string linkText, string actionName, string idValue)
        {
            return htmlHelper.ActionLink(linkText, actionName, new { id = idValue });
        }
    }
}
