using System.Web.Mvc;
using System.Web.Mvc.Html;
using GDNET.FrameworkInfrastructure.Services;

namespace GDNET.FrameworkInfrastructure.Common.Extensions
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString ActionLinkWithId(this HtmlHelper htmlHelper, string linkText, string actionName, string idValue)
        {
            return htmlHelper.ActionLink(linkText, actionName, new { id = idValue });
        }

        public static MvcHtmlString ActionLinkTrans(this HtmlHelper htmlHelper, string textKeyword, string actionName)
        {
            string linkText = WebFrameworkServices.Translation.GetByKeyword(textKeyword);
            return htmlHelper.ActionLink(linkText, actionName);
        }

        public static MvcHtmlString ActionLinkTrans(this HtmlHelper htmlHelper, string textKeyword, string actionName, string controllerName)
        {
            string linkText = WebFrameworkServices.Translation.GetByKeyword(textKeyword);
            return htmlHelper.ActionLink(linkText, actionName, controllerName);
        }

        public static MvcHtmlString ActionLinkTrans(this HtmlHelper htmlHelper, string textKeyword, string actionName, string controllerName, string tooltipKeyword)
        {
            string linkText = WebFrameworkServices.Translation.GetByKeyword(textKeyword);
            object htmlAttributes = new
            {
                title = WebFrameworkServices.Translation.GetByKeyword(tooltipKeyword)
            };

            return htmlHelper.ActionLink(linkText, actionName, controllerName, null, htmlAttributes);
        }


        #region ValidationSummary methods

        public static MvcHtmlString ValidationSummaryTrans(this HtmlHelper htmlHelper, bool excludePropertyErrors, string messageKeyword)
        {
            string message = WebFrameworkServices.Translation.GetByKeyword(messageKeyword);
            return htmlHelper.ValidationSummary(excludePropertyErrors, message);
        }

        #endregion

        public static MvcHtmlString Translate(this HtmlHelper htmlHelper, string keyword)
        {
            string value = WebFrameworkServices.Translation.GetByKeyword(keyword);
            return MvcHtmlString.Create(value);
        }

        public static MvcHtmlString Translate(this HtmlHelper htmlHelper, string keyword, params object[] objects)
        {
            string value = string.Format(WebFrameworkServices.Translation.GetByKeyword(keyword), objects);
            return MvcHtmlString.Create(value);
        }
    }
}
