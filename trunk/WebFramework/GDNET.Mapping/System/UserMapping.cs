using System;
using GDNET.Domain.Entities.System;
using GDNET.Mapping.Base;
using GDNET.NHibernate.Mapping;
using GDNET.Utils;
using NHibernate.Mapping.ByCode;

namespace GDNET.Data.System
{
    public class UserMapping : AbstractJoinedSubclassMapping<User, Guid>, IEntityMapping
    {
        public UserMapping()
        {
            var defaultEmployee = default(Employee);
            var pis = typeof(Employee).GetMember(ExpressionAssistant.GetPropertyName(() => defaultEmployee.User));

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

            base.OneToOne(e => e.Employee, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Access(Accessor.Property);
                m.Cascade(Cascade.All | Cascade.DeleteOrphans);
                m.PropertyReference(pis[0]);
            });
        }
    }
}
