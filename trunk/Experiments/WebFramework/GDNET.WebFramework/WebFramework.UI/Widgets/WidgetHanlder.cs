using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using WebFramework.Base.Framework.System;

namespace WebFramework.UI.Widgets
{
    public sealed class WidgetHanlder
    {
        private HtmlHelper html;

        public WidgetHanlder(HtmlHelper html)
        {
            this.html = html;
        }

        public void DisplayContent(PageModel page, string zoneCode)
        {
            var zoneModel = page.ZoneModels.FirstOrDefault(x => x.Code == zoneCode);
            if (zoneModel != null)
            {
                foreach (var region in zoneModel.Regions)
                {
                    string viewName = string.Format("{0}/{1}", region.Widget.TechnicalName, "Index");
                    this.html.RenderPartial(viewName, region);
                }
            }
        }
    }
}
