using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace GDNET.Web.Extensions
{
    public static class JQueryAutoCompleteAssistant
    {
        public static MvcHtmlString AutoComplete(this HtmlHelper htmlHelper)
        {
            string randomName = Guid.NewGuid().ToString().Replace("-", string.Empty);
            return htmlHelper.TextBox(randomName);
        }
    }
}
