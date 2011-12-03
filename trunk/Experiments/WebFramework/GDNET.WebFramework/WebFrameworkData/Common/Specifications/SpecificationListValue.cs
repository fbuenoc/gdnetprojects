using GDNET.Common.Data;
using GDNET.Common.Base.Entities;
using GDNET.NHibernateImpl.Data;

using WebFrameworkDomain.Common;
using WebFrameworkDomain.Common.Extensions;

namespace WebFrameworkData.Common.Specifications
{
    public class SpecificationListValue : NHSpecificationBase<ListValue, long>
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

        public override bool OnSaved(ListValue entity)
        {
            entity.RefreshTranslation(entity.Description, ListValueMeta.Description);

            return base.OnSaved(entity);
        }
    }
}
