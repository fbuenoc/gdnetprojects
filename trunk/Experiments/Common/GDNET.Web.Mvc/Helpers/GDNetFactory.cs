using System.Web.Mvc;

namespace GDNET.Web.Mvc.Helpers
{
    public partial class GDNetFactory
    {
        private HtmlHelper htmlHelper;

        public GDNetFactory(HtmlHelper html)
        {
            this.htmlHelper = html;
        }
    }
}
