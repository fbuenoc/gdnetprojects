using GDNET.Data.Base;
using GDNET.Domain.System;
using GDNET.NHibernate.Mapping;
using NHibernate.Mapping.ByCode;

namespace GDNET.Data.System
{
    public class UserMapping : AbstractEntityWithModificationHistoryTMapping<User, long>, IEntityMapping
    {
        public UserMapping()
            : base(Generators.Native)
        {
            base.Property(e => e.Email);
            base.Property(e => e.DisplayName);
            base.Property(e => e.IsActive);
        }
    }
}
