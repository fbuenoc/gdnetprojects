using GDNET.NHibernate.Specifications;
using WebFrameworkDomain.Common;

namespace WebFrameworkData.Common.Specifications
{
    public class SpecificationApplication : AbstractSpecification<Application, long>
    {
        public override bool OnSaving(Application entity)
        {
            return base.OnSaving(entity);
        }
    }
}
