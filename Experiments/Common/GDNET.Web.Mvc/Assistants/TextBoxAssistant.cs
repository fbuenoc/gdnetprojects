using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace GDNET.Web.Mvc.Assistants
{
    public static class TextBoxAssistant
    {
        public static MvcHtmlString ShowTextBox(this HtmlHelper html, string name, object value, bool isEnabled)
        {
            if (isEnabled)
            {
                return html.TextBox(name, value);
            }
            else
            {
                return html.TextBox(name, value, new { disabled = "disabled" });
            }
        }
    }
}
