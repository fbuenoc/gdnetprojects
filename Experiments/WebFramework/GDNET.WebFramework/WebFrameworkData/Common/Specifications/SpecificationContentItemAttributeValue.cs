using GDNET.Common.Base.Entities;
using GDNET.Extensions;
using GDNET.NHibernateImpl.Data;

using WebFrameworkDomain.Common;
using WebFrameworkDomain.Extensions;

namespace WebFrameworkData.Common.Specifications
{
    public class SpecificationContentItemAttributeValue : NHSpecificationBase<ContentItemAttributeValue, long>
    {
        public override bool OnSaved(ContentItemAttributeValue entity)
        {
            // Update translation code
            entity.RefreshTranslation(entity.Value, ExpressionHelper.GetPropertyName(() => entity.Value));

            return base.OnSaved(entity);
        }
    }
}
