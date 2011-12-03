using GDNET.Common.Base.Entities;
using GDNET.NHibernateImpl.Data;

using WebFrameworkDomain.Common;
using WebFrameworkDomain.Common.Extensions;

namespace WebFrameworkData.Common.Specifications
{
    public class SpecificationContentItemAttributeValue : NHSpecificationBase<ContentItemAttributeValue, long>
    {
        public override bool OnSaving(ContentItemAttributeValue entity)
        {
            return base.OnSaving(entity);
        }

        public override bool OnSaved(ContentItemAttributeValue entity)
        {
            entity.RefreshTranslation(entity.Value, ContentItemAttributeValueMeta.Value);

            return base.OnSaved(entity);
        }
    }
}
