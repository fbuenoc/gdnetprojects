using System;
using GDNET.Common.Base;
using GDNET.Common.Security.DefaultImpl;

namespace GDNET.Common.Data
{
    public static class DataService
    {
        public static bool SetCreationInfo(IModification entity)
        {
            return DataService.UpdateCreModInfo(entity, false);
        }

        public static bool SetModificationInfo(IModification entity)
        {
            return DataService.UpdateCreModInfo(entity, true);
        }

        private static bool UpdateCreModInfo(IModification entity, bool includeModified)
        {
            entity.CreatedAt = DateTime.Now;
            entity.CreatedBy = SessionService.Instance.User.Identity.Name;

            if (includeModified)
            {
                entity.LastModifiedAt = DateTime.Now;
                entity.LastModifiedBy = SessionService.Instance.User.Identity.Name;
            }

            return true;
        }
    }
}
