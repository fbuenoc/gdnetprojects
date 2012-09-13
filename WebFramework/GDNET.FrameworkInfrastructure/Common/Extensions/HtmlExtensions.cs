using System.Threading;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using GDNET.Domain.Repositories;

namespace GDNET.FrameworkInfrastructure.Common.Extensions
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString ActionLinkWithId(this HtmlHelper htmlHelper, string linkText, string actionName, string idValue)
        {
            return htmlHelper.ActionLink(linkText, actionName, new { id = idValue });
        }

        public static MvcHtmlString ActionLinkTrans(this HtmlHelper htmlHelper, string keyword, string actionName)
        {
            string linkText = DomainRepositories.Translation.GetValueByKeyword(keyword, Thread.CurrentThread.CurrentUICulture);
            return htmlHelper.ActionLink(linkText, actionName);
        }

        public static MvcHtmlString ActionLinkTrans(this HtmlHelper htmlHelper, string keyword, string actionName, string controllerName)
        {
            string linkText = DomainRepositories.Translation.GetValueByKeyword(keyword, Thread.CurrentThread.CurrentUICulture);
            return htmlHelper.ActionLink(linkText, actionName, controllerName);
        }
    }
}
