using System.Web.Mvc;
using System.Web.Mvc.Html;
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

        public MvcHtmlString ActionListLink(string entityName, string actionName)
        {
            return this.htmlHelper.ActionLink(new SystemTranslation().ReturnToListOfXYZ(entityName), actionName);
        }
    }
}
