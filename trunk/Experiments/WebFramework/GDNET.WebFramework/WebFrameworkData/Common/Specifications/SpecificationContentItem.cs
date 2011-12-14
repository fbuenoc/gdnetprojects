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
            this.UpdateContentItem(entity);
            return base.OnSaving(entity);
        }

        public override bool OnUpdating(ContentItem entity)
        {
            this.UpdateContentItem(entity);
            return base.OnUpdating(entity);
        }

        private void UpdateContentItem(ContentItem entity)
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
        }
    }
}
