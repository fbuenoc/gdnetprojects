using System.Web.Mvc;
using GDNET.Web.Mvc.Assistants;

namespace GDNET.Web.Mvc.Helpers
{
    public partial class GDNetFactory
    {
        public MvcHtmlString TextBox(string name, object value, bool isEnabled)
        {
            return this.htmlHelper.ShowTextBox(name, value, isEnabled);
        }
    }
}
