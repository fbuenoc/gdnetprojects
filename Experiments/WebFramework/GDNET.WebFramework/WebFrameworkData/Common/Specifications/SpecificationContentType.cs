using GDNET.Common.Base;
using GDNET.Common.Data;
using GDNET.Common.Base.Entities;
using GDNET.NHibernateImpl.Data;

using WebFrameworkDomain.Common;
using WebFrameworkDomain.Extensions;

namespace WebFrameworkData.Common.Specifications
{
    public class SpecificationContentType : NHSpecificationBase<ContentType, long>
    {
        public override bool OnSaving(ContentType entity)
        {
            this.UpdateContentType(entity);

            return base.OnSaving(entity);
        }

        public override bool OnUpdating(ContentType entity)
        {
            this.UpdateContentType(entity);

            return base.OnUpdating(entity);
        }

        public override bool OnSaved(ContentType entity)
        {
            // Update translation code
            entity.RefreshTranslation(entity.Name, ExpressionHelper.GetPropertyName(() => entity.Name));

            return base.OnSaved(entity);
        }

        private void UpdateContentType(ContentType entity)
        {
            // In case of creating new ContentType, its Name is also saved. But Description.CreatedDate may be not set
            if (entity.Name != null)
            {
                bool x = (entity.Name.Id < 1) ? DataService.SetCreationInfo(entity.Name) : DataService.SetModificationInfo(entity.Name);
            }

            // For its content attributes
            foreach (var attribute in entity.ContentAttributes)
            {
                bool x = (attribute.Id < 1) ? DataService.SetCreationInfo(attribute) : DataService.SetModificationInfo(attribute);
            }
        }
    }
}
