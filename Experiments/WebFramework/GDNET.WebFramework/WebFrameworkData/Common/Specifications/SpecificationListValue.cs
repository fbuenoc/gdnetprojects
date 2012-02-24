using GDNET.NHibernate.Specifications;
using WebFrameworkDomain.Common;

namespace WebFrameworkData.Common.Specifications
{
    public class SpecificationListValue : AbstractSpecification<ListValue, long>
    {
        public override bool OnSaving(ListValue entity)
        {
            return base.OnSaving(entity);
        }
    }
}
