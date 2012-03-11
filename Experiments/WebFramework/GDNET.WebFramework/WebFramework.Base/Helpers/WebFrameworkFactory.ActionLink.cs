using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace WebFramework.Base.Helpers
{
    public partial class WebFrameworkFactory
    {
        public MvcHtmlString ActionLink(string linkCodeText, string actionName, string controllerName)
        {
            string linkText = TranslationAssistant.Translate(linkCodeText);
            return this.htmlHelper.ActionLink(linkText, actionName, controllerName);
        }
    }
}
