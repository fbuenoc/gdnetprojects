using System;
using NHibernate.Mapping.ByCode;
using WebFramework.Domain.Common;
using WebFramework.Mapping.Base;

namespace WebFramework.Mapping.Common
{
    public class StatutLogMap : AbstractEntityMapping<StatutLog, Guid>, INHibernateMapping
    {
        public StatutLogMap()
            : base(Generators.Assigned)
        {
            base.Property(e => e.Description);
            base.Property(e => e.BackupData);
            base.Property(e => e.CreatedAt);
            base.Property(e => e.CreatedBy);

            base.ManyToOne(e => e.Statut, m =>
            {
                m.Lazy(LazyRelation.NoLazy);
                m.Cascade(Cascade.None);
                m.Column(MappingConstants.StatutLog.StatutId);
            });

            base.ManyToOne(e => e.LifeCycle, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Cascade(Cascade.None);
                m.Column(MappingConstants.StatutLifeCycleId);
            });
        }
    }
}
