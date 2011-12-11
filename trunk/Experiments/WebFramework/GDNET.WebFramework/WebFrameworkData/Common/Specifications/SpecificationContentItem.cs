using GDNET.Common.Base;
using GDNET.Common.Base.Entities;
using GDNET.Common.Data;
using GDNET.NHibernateImpl.Data;

using WebFrameworkDomain.Common;
using WebFrameworkDomain.Extensions;

namespace WebFrameworkData.Common.Specifications
{
    public class SpecificationContentItem : NHSpecificationBase<ContentItem, long>
    {
        public override bool OnSaving(ContentItem entity)
        {
            // In case of creating new ContentItem, its Name is also saved. But Name.CreatedDate may be not set
            if (entity.Name != null)
            {
                var x = (entity.Name.Id < 1) ? DataService.SetCreationInfo(entity.Name) : DataService.SetModificationInfo(entity.Name);
            }
            if (entity.Description != null)
            {
                var x = (entity.Description.Id < 1) ? DataService.SetCreationInfo(entity.Description) : DataService.SetModificationInfo(entity.Description);
            }
            foreach (var attributeValue in entity.AttributeValues)
            {
                if (attributeValue.Value != null)
                {
                    var x = (attributeValue.Value.Id < 1) ? DataService.SetCreationInfo(attributeValue.Value) : DataService.SetModificationInfo(attributeValue.Value);
                }
            }

            return base.OnSaving(entity);
        }

        public override bool OnSaved(ContentItem entity)
        {
            // Update translations
            entity.RefreshTranslation(entity.Name, ExpressionUtil.GetPropertyName(() => entity.Name));
            entity.RefreshTranslation(entity.Description, ExpressionUtil.GetPropertyName(() => entity.Description));
            foreach (var attributeValue in entity.AttributeValues)
            {
                attributeValue.RefreshTranslation(attributeValue.Value, ExpressionUtil.GetPropertyName(() => attributeValue.Value));
            }

            return base.OnSaved(entity);
        }
    }
}
