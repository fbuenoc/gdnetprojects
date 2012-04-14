using System.Web.Mvc;

namespace GDNET.Web.Mvc.Managers
{
    public sealed class ControlManager
    {
        private HtmlHelper html;

        public ControlManager(HtmlHelper html)
        {
            this.html = html;
        }

        public MvcHtmlString AutoCompleteTextBox()
        {
            return MvcHtmlString.Empty;
        }
    }
}
