using GDNET.Common.Data;
using GDNET.NHibernate.Specifications;
using WebFrameworkDomain.Common;

namespace WebFrameworkData.Common.Specifications
{
    public class SpecificationListValue : AbstractSpecification<ListValue, long>
    {
        public override bool OnSaving(ListValue entity)
        {
            // In case of creating new ListValue, its Description is also saved. But Description.CreatedDate may be not set
            if (entity.Description != null)
            {
                var x = (entity.Description.Id < 1) ? DataService.SetCreationInfo(entity.Description) : DataService.SetModificationInfo(entity.Description); ;
            }

            return base.OnSaving(entity);
        }
    }
}
