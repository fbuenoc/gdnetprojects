﻿using System.Linq;
using System.Web.Mvc;
using GDNET.Web.Helpers;
using GDNET.Web.Mvc.Adapters;
using WebFramework.Common.Common;
using WebFramework.Common.Controllers;
using WebFramework.Common.Framework.System;
using WebFramework.Common.Security;
using WebFramework.Domain;
using WebFramework.Domain.Constants;
using WebFramework.Domain.System;

namespace WebFramework.Widgets.Daskboard.Controllers
{
    public class MonitorController : AbstractController, IRequiredAuthenticatedController
    {
        #region Region management

        public ActionResult Region()
        {
            Region regionEntity = null;
            RegionModel regionModel = null;

            if (this.GetRegionModel(out regionModel, out regionEntity))
            {
                return base.View(regionModel);
            }

            return base.RedirectToAction("OnError", "Home");
        }

        [HttpPost]
        public ActionResult Region(FormCollection collection)
        {
            Region regionEntity = null;
            RegionModel regionModel = null;

            if (this.GetRegionModel(out regionModel, out regionEntity))
            {
                // Name & Description of the Region
                var nameEditorAdapter = new TextBoxEditorAdapter("RG_Name", collection);
                regionEntity.Name = nameEditorAdapter.Value;

                var descriptionEditorAdapter = new HtmlEditorAdapter("RG_Description", collection);
                regionEntity.Description = descriptionEditorAdapter.Value;

                foreach (var property in regionModel.Properties)
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
                        var setting = regionEntity.Settings.FirstOrDefault(x => x.WidgetProperty.Code == property.Key.Code);
                        if (setting != null)
                        {
                            setting.Value = newValue;
                        }
                    }
                }

                DomainRepositories.RepositoryAssistant.Flush();
                return base.View(regionModel);
            }

            return base.RedirectToAction("OnError", "Home");
        }

        private bool GetRegionModel(out RegionModel regionModel, out Region regionEntity)
        {
            regionModel = null;
            regionEntity = null;

            long? zoneId = QueryStringAssistant.ParseInteger(EntityQueryString.ZoneId);
            long? regionId = QueryStringAssistant.ParseInteger(EntityQueryString.RegionId);

            if (zoneId.HasValue && regionId.HasValue)
            {
                var zone = DomainRepositories.Zone.GetById(zoneId.Value);
                if (zone != null)
                {
                    regionEntity = zone.Regions.FirstOrDefault(x => x.Id == regionId.Value);
                    regionModel = new RegionModel(regionEntity);
                    return true;
                }
            }

            return false;
        }

        #endregion
    }
}
