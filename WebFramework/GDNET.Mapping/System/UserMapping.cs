using System;
using GDNET.Domain.System;
using GDNET.Mapping.Base;
using GDNET.NHibernate.Mapping;

namespace GDNET.Data.System
{
    public class UserMapping : AbstractJoinedSubclassMapping<User, Guid>, IEntityMapping
    {
        public UserMapping()
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
