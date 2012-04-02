using System.Web.Mvc;
using System.Web.Mvc.Html;
using WebFramework.Common.Framework.Common;
using WebFramework.Domain;
using WebFramework.UI.Translations;

namespace WebFramework.UI.Helpers
{
    public class ActionLinkFactory
    {
        private HtmlHelper htmlHelper;

        public ActionLinkFactory(HtmlHelper htmlHelper)
        {
            this.htmlHelper = htmlHelper;
        }

        public MvcHtmlString ActionLink(string linkCodeText, string actionName)
        {
            string linkText = DomainServices.Translation.Translate(linkCodeText);
            return this.htmlHelper.ActionLink(linkText, actionName);
        }

        public MvcHtmlString ActionLink(string linkCodeText, string actionName, string controllerName)
        {
            string linkText = DomainServices.Translation.Translate(linkCodeText);
            return this.htmlHelper.ActionLink(linkText, actionName, controllerName);
        }

        public MvcHtmlString ActionLink(string linkCodeText, string actionName, string controllerName, object routeValues)
        {
            string linkText = DomainServices.Translation.Translate(linkCodeText);
            return this.htmlHelper.ActionLink(linkText, actionName, controllerName, routeValues, null);
        }

        public MvcHtmlString ActionLinkUpdateValue(ContentItemAttributeValueModel valueModel)
        {
            var routeValues = new { idci = valueModel.ContentItem.Id, id = valueModel.Id };
            return this.ActionLink("SysTranslation.Update", "Edit", "ContentItemAttributeValue", routeValues);
        }

        public MvcHtmlString ActionListLink(string entityName, string actionName)
        {
            return this.htmlHelper.ActionLink(new SystemTranslation().ReturnToListOfXYZ(entityName), actionName);
        }
    }
}
