using System.Linq;
using System.Web.Mvc;
using GDNET.Web.Helpers;
using GDNET.Web.Mvc.Adapters;
using WebFramework.Common.Common;
using WebFramework.Common.Controllers;
using WebFramework.Common.Framework.System;
using WebFramework.Domain;
using WebFramework.Domain.Constants;
using WebFramework.Domain.System;

namespace WebFramework.Controllers
{
    public class RegionAdminController : AbstractController
    {
        private RegionModel currantRegionModel = null;
        private Region currantRegionEntity = null;

        public ActionResult Index()
        {
            if (this.GetRegionModel())
            {
                return base.View(this.currantRegionModel);
            }

            return base.RedirectToAction("OnError", "Home");
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            if (this.GetRegionModel())
            {
                // Name & Description of the Region
                var nameEditorAdapter = new TextBoxEditorAdapter("RG_Name", collection);
                this.currantRegionEntity.Name = nameEditorAdapter.Value;

                var descriptionEditorAdapter = new HtmlEditorAdapter("RG_Description", collection);
                this.currantRegionEntity.Description = descriptionEditorAdapter.Value;

                foreach (var property in this.currantRegionModel.Properties)
                {
                    bool isHandled = true;
                    string newValue = null;
                    string dataTypeName = (property.Key.DataType == null) ? string.Empty : property.Key.DataType.Name;

                    switch (dataTypeName)
                    {
                        case ListValueConstants.ContentDataTypes.TextHtmlEditor:
                            {
                                var editorAdapter = new HtmlEditorAdapter(property.Key.Code, collection);
                                newValue = editorAdapter.Value;
                            }
                            break;

                        case ListValueConstants.ContentDataTypes.NumberNormalNumber:
                            {
                                var editorAdapter = new NumberEditorAdapter(property.Key.Code, collection);
                                newValue = editorAdapter.Value.ToString();
                            }
                            break;

                        case ListValueConstants.ContentDataTypes.TextSimpleTextBox:
                            {
                                var editorAdapter = new TextBoxEditorAdapter(property.Key.Code, collection);
                                newValue = editorAdapter.Value.ToString();
                            }
                            break;

                        default:
                            isHandled = false;
                            break;
                    }

                    if (isHandled)
                    {
                        var setting = this.currantRegionEntity.Settings.FirstOrDefault(x => x.WidgetProperty.Code == property.Key.Code);
                        if (setting != null)
                        {
                            setting.Value = newValue;
                        }
                    }
                }

                DomainRepositories.RepositoryAssistant.Flush();
                return base.View(this.currantRegionModel);
            }

            return base.RedirectToAction("OnError", "Home");
        }

        private bool GetRegionModel()
        {
            long? zoneId = QueryStringAssistant.ParseInteger(EntityQueryString.ZoneId);
            long? regionId = QueryStringAssistant.ParseInteger(EntityQueryString.RegionId);

            if (zoneId.HasValue && regionId.HasValue)
            {
                var zone = DomainRepositories.Zone.GetById(zoneId.Value);
                if (zone != null)
                {
                    this.currantRegionEntity = zone.Regions.FirstOrDefault(x => x.Id == regionId.Value);
                    this.currantRegionModel = new RegionModel(this.currantRegionEntity);
                    return true;
                }
            }

            return false;
        }
    }
}
