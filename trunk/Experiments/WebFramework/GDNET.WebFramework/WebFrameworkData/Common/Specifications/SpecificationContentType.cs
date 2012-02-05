using GDNET.Common.Data;
using GDNET.NHibernate.Specifications;
using WebFrameworkDomain.Common;

namespace WebFrameworkData.Common.Specifications
{
    public class SpecificationContentType : AbstractSpecification<ContentType, long>
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
