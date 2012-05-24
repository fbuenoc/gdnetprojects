using System.Web.Mvc;
using GDNET.Web.Mvc.Assistants;

namespace GDNET.Web.Mvc.Helpers
{
    public partial class GDNetFactory
    {
        public MvcHtmlString TextArea(string name, string value, bool isEnabled)
        {
            return this.TextArea(name, value, isEnabled, null);
        }

        public MvcHtmlString TextArea(string name, string value, bool isEnabled, object htmlAttributes)
        {
            return this.htmlHelper.ShowTextArea(name, value, isEnabled, htmlAttributes);
        }
    }
}
