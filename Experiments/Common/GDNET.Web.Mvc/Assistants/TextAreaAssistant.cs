using System.Web.Mvc;
using System.Web.Mvc.Html;
using Finley.Common;

namespace GDNET.Web.Mvc.Assistants
{
    public static class TextAreaAssistant
    {
        public static MvcHtmlString ShowTextArea(this HtmlHelper html, string name, string value, bool isEnabled, object htmlAttributes)
        {
            if (isEnabled)
            {
                return html.TextArea(name, value, htmlAttributes);
            }
            else
            {
                if (htmlAttributes == null)
                {
                    htmlAttributes = new { disabled = "disabled" };
                }
                else
                {
                    object attr1 = new { disabled = "disabled" };
                    htmlAttributes = TypeMerger.MergeTypes(htmlAttributes, attr1);
                }
                return html.TextArea(name, value, htmlAttributes);
            }
        }
    }
}
