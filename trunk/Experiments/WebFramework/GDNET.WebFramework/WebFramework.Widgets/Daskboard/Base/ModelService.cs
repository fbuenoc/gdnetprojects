using System;
using System.Collections.Generic;
using System.Linq;
using GDNET.Common.DesignByContract;
using WebFramework.Common.Common;
using WebFramework.Domain;
using WebFramework.Widgets.Daskboard.ViewModels;

namespace WebFramework.Widgets.Daskboard.Base
{
    public static class ModelService
    {
        public static TModel GetModelById<TModel>(string id)
        {
            return ModelService.GetModelById<TModel>(id, null);
        }

        public static TModel GetModelById<TModel>(string id, IDictionary<object, object> parameters)
        {
            long modelId;
            object modelEntity = null;
            string modelFullName = typeof(TModel).FullName;

            if (long.TryParse(id, out modelId))
            {
                if (modelFullName == typeof(ApplicationModel).FullName)
                {
                    var app = DomainRepositories.Application.GetById(modelId);
                    modelEntity = new ApplicationModel(app);
                }
                else if (modelFullName == typeof(ContentAttributeModel).FullName)
                {
                    var attr = DomainRepositories.ContentAttribute.GetById(modelId);
                    modelEntity = new ContentAttributeModel(attr);
                }
                else if (modelFullName == typeof(ContentItemModel).FullName)
                {
                    var item = DomainRepositories.ContentItem.GetById(modelId);
                    modelEntity = new ContentItemModel(item);
                }
                else if (modelFullName == typeof(ContentTypeModel).FullName)
                {
                    var type = DomainRepositories.ContentType.GetById(modelId);
                    modelEntity = new ContentTypeModel(type);
                }
                else if (modelFullName == typeof(CultureModel).FullName)
                {
                    var culture = DomainRepositories.Culture.GetById((int)modelId);
                    modelEntity = new CultureModel(culture);
                }
                else if (modelFullName == typeof(ListValueModel).FullName)
                {
                    var lv = DomainRepositories.ListValue.GetById(modelId);
                    modelEntity = new ListValueModel(lv);
                }
                else if (modelFullName == typeof(TranslationModel).FullName)
                {
                    var translation = DomainRepositories.Translation.GetById(modelId);
                    modelEntity = new TranslationModel(translation);
                }
                else if (modelFullName == typeof(ContentItemAttributeValueModel).FullName)
                {
                    if (parameters.ContainsKey(EntityQueryString.ContentItemId))
                    {
                        long contentItemId = (long)parameters[EntityQueryString.ContentItemId];
                        var contentItem = DomainRepositories.ContentItem.GetById(contentItemId);
                        var attributeValue = contentItem.AttributeValues.FirstOrDefault(x => x.Id == modelId);
                        if (attributeValue != null)
                        {
                            modelEntity = new ContentItemAttributeValueModel(attributeValue);
                        }
                    }
                }
                else if (modelFullName == typeof(PageModel).FullName)
                {
                    var page = DomainRepositories.Page.GetById(modelId);
                    modelEntity = new PageModel(page);
                }
                else if (modelFullName == typeof(RegionModel).FullName)
                {
                    long zoneId = (long)parameters[EntityQueryString.ZoneId];
                    modelEntity = ModelService.GetRegionModel(zoneId, modelId);
                }
                else if (modelFullName == typeof(WidgetModel).FullName)
                {
                    var widget = DomainRepositories.Widget.GetById(modelId);
                    modelEntity = new WidgetModel(widget);
                }
                else if (modelFullName == typeof(ZoneModel).FullName)
                {
                    var zone = DomainRepositories.Zone.GetById(modelId);
                    modelEntity = new ZoneModel(zone);
                }
                else
                {
                    ThrowException.NotImplementedException(string.Format("Not implemented for type: '{0}'.", typeof(TModel).FullName));
                }

                if (modelEntity != null)
                {
                    return (TModel)Convert.ChangeType(modelEntity, typeof(TModel));
                }
            }

            return default(TModel);
        }

        private static RegionModel GetRegionModel(long zoneId, long regionId)
        {
            var zoneEntity = DomainRepositories.Zone.GetById(zoneId);
            var regionEntity = zoneEntity.Regions.FirstOrDefault(x => x.Id == regionId);
            if (regionEntity != null)
            {
                return new RegionModel(regionEntity);
            }

            return default(RegionModel);
        }
    }
}
