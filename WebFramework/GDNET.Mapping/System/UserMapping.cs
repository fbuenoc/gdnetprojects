using GDNET.Domain.System;
using GDNET.Mapping.Base;
using GDNET.NHibernate.Mapping;
using NHibernate.Mapping.ByCode;

namespace GDNET.Data.System
{
    public class UserMapping : AbstractEntityWithModificationHistoryTMapping<User, long>, IEntityMapping
    {
        public UserMapping()
            : base(Generators.Native)
        {
            base.Property(e => e.Email, m =>
            {
                m.Unique(true);
            });
            base.Property(e => e.Password, m =>
            {
                m.NotNullable(true);
            });
            base.Property(e => e.DisplayName);
            base.Property(e => e.IsActive, m =>
            {
                m.NotNullable(true);
            });
        }
    }
}
