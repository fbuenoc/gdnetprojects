using GDNET.Common.Base;
using GDNET.Common.Base.Entities;
using GDNET.Common.Data;
using GDNET.NHibernateImpl.Data;

using WebFrameworkDomain.Common;
using WebFrameworkDomain.Extensions;

namespace WebFrameworkData.Common.Specifications
{
    public class SpecificationApplication : NHSpecificationBase<Application, long>
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

        public override bool OnSaved(Application entity)
        {
            entity.RefreshTranslation(entity.Name, ExpressionHelper.GetPropertyName(() => entity.Name));
            entity.RefreshTranslation(entity.Description, ExpressionHelper.GetPropertyName(() => entity.Description));

            return base.OnSaved(entity);
        }
    }
}
