using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Finley.Common;
using GDNET.Extensions;
using GDNET.Web.Mvc;
using GDNET.Web.Mvc.ComponentEditors;
using Telerik.Web.Mvc.UI;
using WebFramework.Common.Constants;
using WebFramework.Common.Framework.Common;
using WebFramework.Common.Framework.System;
using WebFramework.Common.Widgets;
using WebFramework.Domain;
using WebFramework.Domain.Constants;

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

                    if (resultModel != null)
                    {
                        string viewName = string.Format("{0}/{1}/{2}", region.Widget.TechnicalName, this.GetUsageTemplate(region), widget.CurrentView);
                        this.htmlHelper.RenderPartial(viewName, resultModel);
                    }
                }
            }
        }

        public void DisplayRegionSettings(RegionModel regionModel)
        {
            bool isEnabled = true;

            foreach (var property in regionModel.Properties)
            {
                string dataTypeName = (property.Key.DataType == null) ? string.Empty : property.Key.DataType.Name;

                switch (dataTypeName)
                {
                    case ListValueConstants.ContentDataTypes.TextHtmlEditor:
                        {
                            var editorModel = new HtmlEditorComponent(property.Key.Code, property.Value, isEnabled);
                            this.htmlHelper.GDNet().EditorAssistant().RenderEditorComponent(Editors.HtmlEditor, editorModel);
                        }
                        break;
                    case ListValueConstants.ContentDataTypes.NumberNormalNumber:
                        {
                            var editorModel = new NumberEditorComponent(property.Key.Code, Convert.ToDouble(property.Value), isEnabled);
                            this.htmlHelper.GDNet().EditorAssistant().RenderEditorComponent(Editors.NumberEditor, editorModel);
                        }
                        break;
                    case ListValueConstants.ContentDataTypes.TextTextArea:
                        {
                            var editorModel = new TextAreaEditorComponent(property.Key.Code, property.Value, isEnabled);
                            this.htmlHelper.GDNet().EditorAssistant().RenderEditorComponent(Editors.TextAreaEditor, editorModel);
                        }
                        break;
                    case ListValueConstants.ContentDataTypes.TextSimpleTextBox:
                    default:
                        {
                            var editorModel = new TextBoxEditorComponent(property.Key.Code, property.Value, isEnabled);
                            this.htmlHelper.GDNet().EditorAssistant().RenderEditorComponent(Editors.TextBoxEditor, editorModel);
                        }
                        break;
                }
            }
        }

        private string GetUsageTemplate(RegionModel region)
        {
            var setting = region.Properties.FirstOrDefault(x => x.Key.Code == WidgetBaseConstants.PropertyUsageTemplate);
            if (!setting.IsDefault())
            {
                return setting.Value;
            }

            return string.Empty;
        }

        public MvcHtmlString ActionLinkShowMore(RegionModel targetRegion)
        {
            if (targetRegion != null)
            {
                string linkText = DomainServices.Translation.Translate("SysTranslation.ShowMore");
                object routeValues = new { page = targetRegion.Zone.Page.UniqueName };

                return this.ActionLinkToPage(linkText, routeValues, null);
            }
            else
            {
                return MvcHtmlString.Empty;
            }
        }

        public MvcHtmlString ActionLinkAdminister(WidgetModelBase widgetModel)
        {
            string linkText = DomainServices.Translation.Translate("SysTranslation.RegionAdminister");
            return this.htmlHelper.GDNet().HtmlLink(widgetModel.AdministerUrl, linkText);
        }

        public MvcHtmlString ActionLinkAdminister(PageModel pageModel)
        {
            string linkText = DomainServices.Translation.Translate("SysTranslation.PageAdminister");

            var routeValues = new
            {
                idpg = pageModel.Id,
                page = pageModel.UniqueName
            };

            return this.htmlHelper.ActionLink(linkText, "Page", WebFrameworkConstants.Controllers.Monitor, routeValues, null);
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

        public void RegisterStyleSheets(PageModel pageModel)
        {
            List<string> listCssPaths = new List<string>();

            foreach (var zoneModel in pageModel.ZoneModels)
            {
                foreach (var regionModel in zoneModel.Regions)
                {
                    string cssPath = string.Format("Widgets/{0}/{1}/Index.css", regionModel.Widget.TechnicalName, this.GetUsageTemplate(regionModel));
                    if (!listCssPaths.Contains(cssPath))
                    {
                        listCssPaths.Add(cssPath);
                    }
                }
            }

            this.RegisterStyleSheets(listCssPaths);
        }

        public void RegisterStyleSheets()
        {
            this.RegisterStyleSheets(new List<string>());
        }

        private void RegisterStyleSheets(List<string> listCssPaths)
        {
            this.htmlHelper.Telerik().StyleSheetRegistrar().DefaultGroup(dg =>
            {
                dg.Add("Site.css").Add("telerik.common.css").Add("telerik.vista.css");
                foreach (string cssPath in listCssPaths)
                {
                    dg.Add(cssPath);
                }
                dg.Combined(true).Compress(true);
            }).Render();
        }
    }
}
