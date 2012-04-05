using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Finley.Common;
using GDNET.Extensions;
using GDNET.Web.Mvc;
using GDNET.Web.Mvc.ComponentEditors;
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

                    string viewName = string.Format("{0}/{1}/{2}", region.Widget.TechnicalName, this.GetUsageTemplate(region), "Index");
                    this.htmlHelper.RenderPartial(viewName, resultModel);
                }
            }
        }

        public void DisplayRegionSettings(RegionModel regionModel)
        {
            foreach (var property in regionModel.Properties)
            {
                if (property.Key.DataType == null)
                {
                    var textBoxComponentModel = new TextBoxEditorComponent(property.Key.Code, property.Value);
                    this.htmlHelper.RenderPartial("ComponentEditorSimpleTextBox", textBoxComponentModel);
                }
                else
                {
                    switch (property.Key.DataType.Name)
                    {
                        case ListValueConstants.ContentDataTypes.TextHtmlEditor:
                            {
                                var editorModel = new HtmlEditorComponent(property.Key.Code, property.Value);
                                this.htmlHelper.GDNet().EditorAssistant().RenderEditorComponent(Editors.HtmlEditor, editorModel);
                            }
                            break;
                        case ListValueConstants.ContentDataTypes.NumberNormalNumber:
                            {
                                var editorModel = new NumberEditorComponent(property.Key.Code, Convert.ToDouble(property.Value));
                                this.htmlHelper.GDNet().EditorAssistant().RenderEditorComponent(Editors.NumberEditor, editorModel);
                            }
                            break;
                        case ListValueConstants.ContentDataTypes.TextSimpleTextBox:
                            {
                                var editorModel = new TextBoxEditorComponent(property.Key.Code, property.Value);
                                this.htmlHelper.GDNet().EditorAssistant().RenderEditorComponent(Editors.TextBoxEditor, editorModel);
                            }
                            break;
                        case ListValueConstants.ContentDataTypes.TextTextArea:
                            {
                                var editorModel = new TextAreaEditorComponent(property.Key.Code, property.Value);
                                this.htmlHelper.GDNet().EditorAssistant().RenderEditorComponent(Editors.TextAreaEditor, editorModel);
                            }
                            break;
                    }
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
            string linkText = DomainServices.Translation.Translate("SysTranslation.ShowMore");
            object routeValues = new { page = targetRegion.Zone.Page.UniqueName };

            return this.ActionLinkToPage(linkText, routeValues, null);
        }

        public MvcHtmlString ActionLinkAdminister(WidgetModelBase widgetModel)
        {
            string linkText = DomainServices.Translation.Translate("SysTranslation.RegionAdminister");

            var routeValues = new
            {
                area = string.Empty,
                idzn = widgetModel.IdZone,
                idrg = widgetModel.IdRegion
            };

            return this.htmlHelper.ActionLink(linkText, "Index", WebFrameworkConstants.Controllers.RegionAdmin, routeValues, null);
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
