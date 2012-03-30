using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using WebFramework.Common.Framework.System;
using WebFramework.Common.Widgets;

namespace WebFramework.UI.Widgets
{
    public class WidgetHanlder
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
                    var objet = Activator.CreateInstance(region.Widget.AssemblyName, region.Widget.ClassName);
                    var widget = objet.Unwrap() as IWidget;
                    object resultModel = widget.Initialize(region);

                    string viewName = string.Format("{0}/{1}", region.Widget.TechnicalName, "Index");
                    this.html.RenderPartial(viewName, resultModel);
                }
            }
        }
    }
}
