using System;

using GDNET.Common.Base.Entities;
using GDNET.Common.Security;
using GDNET.Common.Security.DefaultImpl;

namespace GDNET.Common.Data
{
    public static class DataService
    {
        public static bool SetCreationInfo(IEntityCreMod entity)
        {
            return DataService.UpdateCreModInfo(entity, false);
        }

        public static bool SetModificationInfo(IEntityCreMod entity)
        {
            return DataService.UpdateCreModInfo(entity, true);
        }

        private static bool UpdateCreModInfo(IEntityCreMod entity, bool includeModified)
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
