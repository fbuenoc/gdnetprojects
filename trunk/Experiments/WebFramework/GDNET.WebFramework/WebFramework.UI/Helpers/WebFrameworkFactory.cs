using System.Web.Mvc;
using WebFramework.UI.Widgets;

namespace WebFramework.UI.Helpers
{
    public partial class WebFrameworkFactory
    {
        private HtmlHelper htmlHelper;

        public WebFrameworkFactory(HtmlHelper html)
        {
            this.htmlHelper = html;
        }

        public WidgetHanlder WidgetHanlder()
        {
            return new WidgetHanlder(this.htmlHelper);
        }
    }
}