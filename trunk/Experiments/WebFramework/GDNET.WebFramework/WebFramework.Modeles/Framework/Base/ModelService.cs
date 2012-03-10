using System;
using GDNET.Common.DesignByContract;
using WebFramework.Base.Framework.Common;
using WebFrameworkDomain.DefaultImpl;

namespace WebFramework.Base.Framework.Base
{
    public static class ModelService
    {
        public static TModel GetModelById<TModel>(string id)
        {
            long modelId;

            if (long.TryParse(id, out modelId))
            {
                if (typeof(TModel).FullName == typeof(ApplicationModel).FullName)
                {
                    var app = DomainRepositories.Application.GetById(modelId);
                    if (app != null)
                    {
                        return (TModel)Convert.ChangeType(new ApplicationModel(app), typeof(TModel));
                    }
                }
                else if (typeof(TModel).FullName == typeof(ListValueModel).FullName)
                {
                    var lv = DomainRepositories.ListValue.GetById(modelId);
                    if (lv != null)
                    {
                        return (TModel)Convert.ChangeType(new ListValueModel(lv), typeof(TModel));
                    }
                }
                else if (typeof(TModel).FullName == typeof(ContentTypeModel).FullName)
                {
                    var type = DomainRepositories.ContentType.GetById(modelId);
                    if (type != null)
                    {
                        return (TModel)Convert.ChangeType(new ContentTypeModel(type), typeof(TModel));
                    }
                }
                else if (typeof(TModel).FullName == typeof(ContentItemModel).FullName)
                {
                    var item = DomainRepositories.ContentItem.GetById(modelId);
                    if (item != null)
                    {
                        return (TModel)Convert.ChangeType(new ContentItemModel(item), typeof(TModel));
                    }
                }
                else if (typeof(TModel).FullName == typeof(ContentAttributeModel).FullName)
                {
                    var attr = DomainRepositories.ContentAttribute.GetById(modelId);
                    if (attr != null)
                    {
                        return (TModel)Convert.ChangeType(new ContentAttributeModel(attr), typeof(TModel));
                    }
                }
                else
                {
                    ThrowException.NotImplementedException(string.Format("Not implemented for type: '{0}'.", typeof(TModel).FullName));
                }
            }

            return default(TModel);
        }
    }
}
