using System.Web.Mvc;
using System.Web.Mvc.Html;
using WebFramework.Domain;

namespace WebFramework.UI.Helpers
{
    public partial class WebFrameworkFactory
    {
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
            return this.htmlHelper.ActionLink(this.SysTranslations.ReturnToListOfXYZ(entityName), actionName);
        }
    }
}
