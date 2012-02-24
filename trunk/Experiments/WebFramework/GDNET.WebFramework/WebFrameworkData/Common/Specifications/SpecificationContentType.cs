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
        }
    }
}
