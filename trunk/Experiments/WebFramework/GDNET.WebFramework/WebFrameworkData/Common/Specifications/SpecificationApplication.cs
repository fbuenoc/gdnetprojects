using GDNET.Common.Data;
using GDNET.NHibernate.Specifications;
using WebFrameworkDomain.Common;

namespace WebFrameworkData.Common.Specifications
{
    public class SpecificationApplication : AbstractSpecification<Application, long>
    {
        public override bool OnSaving(Application entity)
        {
            // In case of creating new Application, its Name is also saved. But Name.CreatedDate may be not set
            if (entity.Name != null)
            {
                var x = (entity.Name.Id < 1) ? DataService.SetCreationInfo(entity.Name) : DataService.SetModificationInfo(entity.Name);
            }
            if (entity.Description != null)
            {
                var x = (entity.Description.Id < 1) ? DataService.SetCreationInfo(entity.Description) : DataService.SetModificationInfo(entity.Description);
            }

            return base.OnSaving(entity);
        }
    }
}
