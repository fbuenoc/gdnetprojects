﻿using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Finley.Common;
using GDNET.Extensions;
using WebFramework.Common.Framework.Common;
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

                    string viewName = string.Format("{0}/{1}/{2}", region.Widget.TechnicalName, this.GetUsageTemplate(region), "Index");
                    this.htmlHelper.RenderPartial(viewName, resultModel);
                }
            }
        }

        private string GetUsageTemplate(RegionModel region)
        {
            var setting = region.Properties.FirstOrDefault(x => x.Key == WidgetBaseConstants.PropertyUsageTemplate);
            if (!setting.IsDefault())
            {
                return setting.Value;
            }

            return string.Empty;
        }

        public MvcHtmlString ActionLinkShowMore(RegionModel targetRegion)
        {
            string linkText = DomainServices.Translation.Translate("SysTranslation.ShowMore");
            object routeValues = new { page = targetRegion.Zone.Page.UniqueName };

            return this.ActionLinkToPage(linkText, routeValues, null);
        }

        public MvcHtmlString ActionLinkContentItem(ContentItemModel itemModel, RegionModel targetRegion)
        {
            var htmlAttributes = new
            {
                title = itemModel.Description.StripTagsRegex()
            };

            object routeValues = new
            {
                idci = itemModel.Id.ToString(),
            };

            if (targetRegion != null)
            {
                object routeValue2 = new
                {
                    page = targetRegion.Zone.Page.UniqueName,
                };
                routeValues = TypeMerger.MergeTypes(routeValue2, routeValues);
            }

            return this.ActionLinkToPage(itemModel.Name, routeValues, htmlAttributes);
        }

        private MvcHtmlString ActionLinkToPage(string linkText, object routeValues, object htmlAttributes)
        {
            return this.htmlHelper.ActionLink(linkText, "Index", "Page", routeValues, htmlAttributes);
        }
    }
}
