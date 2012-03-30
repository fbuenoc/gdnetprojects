using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using GDNET.Web.Helpers;
using WebFramework.Common.Framework.System;
using WebFramework.Common.Widgets;
using WebFramework.Domain;

namespace WebFramework.UI.Widgets
{
    public class WidgetHanlder
    {
        private HtmlHelper htmlHelper;

        public WidgetHanlder(HtmlHelper htmlHelper)
        {
            this.htmlHelper = htmlHelper;
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
                    this.htmlHelper.RenderPartial(viewName, resultModel);
                }
            }
        }

        public MvcHtmlString ActionLinkShowMore(RegionModel targetRegion, object routeValues)
        {
            string linkText = DomainServices.Translation.Translate("SysTranslation.ShowMore");
            Dictionary<string, string> htmlAttributes = new Dictionary<string, string>();

            object routeValues2 = new { page = targetRegion.Zone.Page.UniqueName };
            object mergedRouteValues = MergingAssistant.Merge(routeValues, routeValues2);

            return this.htmlHelper.ActionLink(linkText, "Index", "Page", mergedRouteValues, htmlAttributes);
        }
    }
}
