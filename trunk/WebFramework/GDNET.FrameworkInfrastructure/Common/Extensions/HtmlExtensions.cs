using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using GDNET.Domain.Repositories;
using GDNET.FrameworkInfrastructure.Services;

namespace GDNET.FrameworkInfrastructure.Common.Extensions
{
    public static class HtmlExtensions
    {
        #region ActionLinkTrans

        public static MvcHtmlString ActionLinkTrans(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, object routeValues, string titleKeyword)
        {
            string titleText = WebFrameworkServices.Translation.GetByKeyword(titleKeyword);
            return htmlHelper.ActionLink(linkText, actionName, controllerName, routeValues, new { title = titleText });
        }

        public static MvcHtmlString ActionLinkTrans(this HtmlHelper htmlHelper, string textKeyword, string actionName)
        {
            string linkText = WebFrameworkServices.Translation.GetByKeyword(textKeyword);
            return htmlHelper.ActionLink(linkText, actionName);
        }

        public static MvcHtmlString ActionLinkTrans(this HtmlHelper htmlHelper, string textKeyword, string actionName, object routeValues)
        {
            string linkText = WebFrameworkServices.Translation.GetByKeyword(textKeyword);
            return htmlHelper.ActionLink(linkText, actionName, routeValues);
        }

        public static MvcHtmlString ActionLinkTrans(this HtmlHelper htmlHelper, string textKeyword, string actionName, string controllerName)
        {
            string linkText = WebFrameworkServices.Translation.GetByKeyword(textKeyword);
            return htmlHelper.ActionLink(linkText, actionName, controllerName);
        }

        public static MvcHtmlString ActionLinkTrans(this HtmlHelper htmlHelper, string textKeyword, string actionName, string controllerName, object routeValues)
        {
            string linkText = WebFrameworkServices.Translation.GetByKeyword(textKeyword);
            return htmlHelper.ActionLink(linkText, actionName, controllerName, routeValues, null);
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

        #endregion

        #region ValidationSummary

        public static MvcHtmlString ValidationSummaryTrans(this HtmlHelper htmlHelper, bool excludePropertyErrors, string messageKeyword)
        {
            string message = WebFrameworkServices.Translation.GetByKeyword(messageKeyword);
            return htmlHelper.ValidationSummary(excludePropertyErrors, message);
        }

        #endregion

        #region Translate

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

        #endregion

        public static MvcHtmlString TextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string className)
        {
            return htmlHelper.TextBoxFor(expression, new { @class = className });
        }

        public static MvcHtmlString TextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string className)
        {
            return htmlHelper.TextAreaFor(expression, new { @class = className });
        }

        public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string catalogCode)
        {
            List<SelectListItem> listItems = new List<SelectListItem>();

            var catalog = DomainRepositories.Catalog.FindByCode(catalogCode);
            if (catalog != null)
            {
                listItems.AddRange(catalog.Lines.Select(x => new SelectListItem() { Value = x.Code, Text = x.Name }));
            }

            return htmlHelper.DropDownListFor(expression, listItems);
        }

        public static MvcHtmlString ActionLinkWithId(this HtmlHelper htmlHelper, string linkText, string actionName, string idValue)
        {
            return htmlHelper.ActionLink(linkText, actionName, new { id = idValue });
        }

        public static MvcHtmlString ActionLinkConfirmation(this HtmlHelper htmlHelper, string textKeyword, string messageKeyword, string actionName, object routeValues)
        {
            string linkText = WebFrameworkServices.Translation.GetByKeyword(textKeyword);
            string messageText = WebFrameworkServices.Translation.GetByKeyword(messageKeyword);
            string javascript = string.Format("return confirm(\"{0}\");", messageText);

            return htmlHelper.ActionLink(linkText, actionName, routeValues, new { onclick = javascript });
        }
    }
}
