using System.Linq;
using System.Web.Mvc;
using GDNET.Web.Mvc.Adapters;
using WebFramework.Common.Controllers;
using WebFramework.Common.Framework.System;
using WebFramework.Common.Security;
using WebFramework.Domain;
using WebFramework.Domain.Constants;
using WebFramework.Extensions;

namespace WebFramework.Widgets.HtmlContentWg.Controllers
{
    public class AdminController : AbstractController<HtmlContentModel>, IRequiredManagerController
    {
        public ActionResult Index()
        {
            var region = ControllerAssistant.GetCurrentRegion();
            var regionModel = new RegionModel(region);

            return base.View(regionModel);
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            var regionEntity = ControllerAssistant.GetCurrentRegion();
            if (regionEntity != null)
            {
                // Name & Description of the Region
                var nameEditorAdapter = new TextBoxEditorAdapter("RG_Name", collection);
                regionEntity.Name = nameEditorAdapter.Value;

                var descriptionEditorAdapter = new HtmlEditorAdapter("RG_Description", collection);
                regionEntity.Description = descriptionEditorAdapter.Value;

                foreach (var property in regionEntity.Settings)
                {
                    bool isHandled = true;
                    string newValue = null, widgetPropertyCode = property.WidgetProperty.Code;
                    string dataTypeName = (property.WidgetProperty.DataType == null) ? string.Empty : property.WidgetProperty.DataType.Name;

                    switch (dataTypeName)
                    {
                        case ListValueConstants.ContentDataTypes.TextHtmlEditor:
                            {
                                var editorAdapter = new HtmlEditorAdapter(widgetPropertyCode, collection);
                                newValue = editorAdapter.Value;
                            }
                            break;

                        case ListValueConstants.ContentDataTypes.NumberNormalNumber:
                            {
                                var editorAdapter = new NumberEditorAdapter(widgetPropertyCode, collection);
                                newValue = editorAdapter.Value.ToString();
                            }
                            break;

                        case ListValueConstants.ContentDataTypes.TextSimpleTextBox:
                            {
                                var editorAdapter = new TextBoxEditorAdapter(widgetPropertyCode, collection);
                                newValue = editorAdapter.Value.ToString();
                            }
                            break;

                        default:
                            isHandled = false;
                            break;
                    }

                    if (isHandled)
                    {
                        var setting = regionEntity.Settings.FirstOrDefault(x => x.WidgetProperty.Code == widgetPropertyCode);
                        if (setting != null)
                        {
                            setting.Value = newValue;
                        }
                    }
                }

                DomainRepositories.RepositoryAssistant.Flush();
                var regionModel = new RegionModel(regionEntity);
                return base.View(regionModel);
            }

            return base.RedirectToAction("OnError", "Home");
        }
    }
}
