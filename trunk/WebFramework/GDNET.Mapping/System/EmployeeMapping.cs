using System;
using GDNET.Domain.Entities.System;
using GDNET.Mapping.Base;
using GDNET.Mapping.Common;
using GDNET.NHibernate.Mapping;
using NHibernate.Mapping.ByCode;

namespace GDNET.Data.System
{
    public class EmployeeMapping : AbstractJoinedSubclassMapping<Employee, Guid>, IEntityMapping
    {
        public EmployeeMapping()
        {
            var defaultEmployee = default(Employee);

            base.Property(e => e.StartDate);
            base.Property(e => e.IsActive, m =>
            {
                m.NotNullable(true);
            });

            base.ManyToOne(e => e.User, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Access(Accessor.Property);
                m.Unique(true);
                m.Cascade(Cascade.All | Cascade.DeleteOrphans);
                m.Column(MappingAssistant.GetForeignKeyColumn(() => defaultEmployee.User));
            });
        }
    }
}
