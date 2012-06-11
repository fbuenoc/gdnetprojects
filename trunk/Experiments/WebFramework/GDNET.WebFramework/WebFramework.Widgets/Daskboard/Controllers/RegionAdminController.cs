using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using GDNET.Web.Helpers;
using GDNET.Web.Mvc.Adapters;
using WebFramework.Common.Constants;
using WebFramework.Common.Controllers;
using WebFramework.Common.Framework.System;
using WebFramework.Common.Security;
using WebFramework.Domain;
using WebFramework.Domain.Constants;
using WebFramework.Domain.System;

namespace WebFramework.Widgets.Daskboard.Controllers
{
    public class RegionAdminController : AbstractController<PageModel>, IRequiredManagerController
    {
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }

        public ActionResult Index()
        {
            var objet = new
            {
                rid = QueryStringAssistant.GetValueAsString(QueryStringConstants.RegionId),
                page = QueryStringAssistant.GetValueAsString(QueryStringConstants.Page)
            };

            return base.RedirectToAction("Edit", objet);
        }

        public ActionResult Edit()
        {
            var regionEntity = this.GetSelectionRegion();

            if (regionEntity == null)
            {
                throw new Exception();
            }
            else
            {
                var regionModel = new RegionModel(regionEntity);
                return base.View(regionModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            var regionEntity = this.GetSelectionRegion();

            if (regionEntity == null)
            {
                throw new Exception();
            }
            else
            {
                var regionModel = new RegionModel(regionEntity);

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
        }

        private Region GetSelectionRegion()
        {
            var regionId = QueryStringAssistant.ParseInteger(QueryStringConstants.RegionId);
            var zoneId = QueryStringAssistant.ParseInteger(QueryStringConstants.ZoneId);
            Region regionEntity = null;

            if (zoneId.HasValue)
            {
                var zoneEntity = DomainRepositories.Zone.GetById(zoneId.Value);
                if (zoneEntity != null && regionId.HasValue)
                {
                    regionEntity = zoneEntity.GetRegionById(regionId.Value);
                }
            }

            return regionEntity;
        }
    }
}
