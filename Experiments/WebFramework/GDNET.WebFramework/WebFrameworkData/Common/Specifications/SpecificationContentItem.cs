using GDNET.NHibernate.Specifications;
using WebFrameworkDomain.Common;

namespace WebFrameworkData.Common.Specifications
{
    public class SpecificationContentItem : AbstractSpecification<ContentItem, long>
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
        }
    }
}
