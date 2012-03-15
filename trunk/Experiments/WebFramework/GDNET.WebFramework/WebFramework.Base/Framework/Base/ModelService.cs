using System;
using GDNET.Common.DesignByContract;
using WebFramework.Base.Framework.Common;
using WebFramework.Domain;

namespace WebFramework.Base.Framework.Base
{
    public static class ModelService
    {
        public static TModel GetModelById<TModel>(string id)
        {
            long modelId;
            object modelEntity = null;

            if (long.TryParse(id, out modelId))
            {
                if (typeof(TModel).FullName == typeof(ApplicationModel).FullName)
                {
                    var app = DomainRepositories.Application.GetById(modelId);
                    modelEntity = new ApplicationModel(app);
                }
                else if (typeof(TModel).FullName == typeof(ContentAttributeModel).FullName)
                {
                    var attr = DomainRepositories.ContentAttribute.GetById(modelId);
                    modelEntity = new ContentAttributeModel(attr);
                }
                else if (typeof(TModel).FullName == typeof(ContentItemModel).FullName)
                {
                    var item = DomainRepositories.ContentItem.GetById(modelId);
                    modelEntity = new ContentItemModel(item);
                }
                else if (typeof(TModel).FullName == typeof(ContentTypeModel).FullName)
                {
                    var type = DomainRepositories.ContentType.GetById(modelId);
                    modelEntity = new ContentTypeModel(type);
                }
                else if (typeof(TModel).FullName == typeof(CultureModel).FullName)
                {
                    var culture = DomainRepositories.Culture.GetById((int)modelId);
                    modelEntity = new CultureModel(culture);
                }
                else if (typeof(TModel).FullName == typeof(ListValueModel).FullName)
                {
                    var lv = DomainRepositories.ListValue.GetById(modelId);
                    modelEntity = new ListValueModel(lv);
                }
                else if (typeof(TModel).FullName == typeof(TranslationModel).FullName)
                {
                    var translation = DomainRepositories.Translation.GetById(modelId);
                    modelEntity = new TranslationModel(translation);
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
    }
}
