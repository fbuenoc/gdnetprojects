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
            // In case of creating new ContentType, its Name is also saved. But Description.CreatedDate may be not set
            if (entity.Name != null)
            {
                bool x = (entity.Name.Id < 1) ? DataService.SetCreationInfo(entity.Name) : DataService.SetModificationInfo(entity.Name);
            }

            return base.OnSaving(entity);
        }

        public override bool OnSaved(ContentType entity)
        {
            entity.RefreshTranslation(entity.Name, ContentTypeMeta.Name);

            return base.OnSaved(entity);
        }
    }
}
