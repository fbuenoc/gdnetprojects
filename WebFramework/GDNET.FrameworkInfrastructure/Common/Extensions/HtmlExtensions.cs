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

        public static MvcHtmlString ActionLinkTrans(this HtmlHelper htmlHelper, string textKeyword, string actionName, string controllerName)
        {
            string linkText = DomainRepositories.Translation.GetValueByKeyword(textKeyword, Thread.CurrentThread.CurrentUICulture);
            return htmlHelper.ActionLink(linkText, actionName, controllerName);
        }

        public static MvcHtmlString ActionLinkTrans(this HtmlHelper htmlHelper, string textKeyword, string actionName, string controllerName, string tooltipKeyword)
        {
            string linkText = DomainRepositories.Translation.GetValueByKeyword(textKeyword, Thread.CurrentThread.CurrentUICulture);
            object htmlAttributes = new
            {
                title = DomainRepositories.Translation.GetValueByKeyword(tooltipKeyword, Thread.CurrentThread.CurrentUICulture)
            };

            return htmlHelper.ActionLink(linkText, actionName, controllerName, null, htmlAttributes);
        }


        #region ValidationSummary methods

        public static MvcHtmlString ValidationSummaryTrans(this HtmlHelper htmlHelper, bool excludePropertyErrors, string messageKeyword)
        {
            string message = DomainRepositories.Translation.GetValueByKeyword(messageKeyword, Thread.CurrentThread.CurrentUICulture);
            return htmlHelper.ValidationSummary(excludePropertyErrors, message);
        }

        #endregion

        public static string Translate(this HtmlHelper htmlHelper, string keyword)
        {
            return DomainRepositories.Translation.GetValueByKeyword(keyword, Thread.CurrentThread.CurrentUICulture);
        }

        public static string Translate(this HtmlHelper htmlHelper, string keyword, params object[] objects)
        {
            return string.Format(DomainRepositories.Translation.GetValueByKeyword(keyword, Thread.CurrentThread.CurrentUICulture), objects);
        }
    }
}
