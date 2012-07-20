using System;
using GDNET.Domain.Base.Management;
using GDNET.Mapping.Base;
using GDNET.Mapping.Common;
using GDNET.NHibernate.Mapping;
using NHibernate.Mapping.ByCode;

namespace GDNET.Mapping.System.Management
{
    public class EntityHistoryComplexMapping : AbstractEntityTMapping<EntityHistoryComplex, Guid>, IEntityMapping
    {
        public EntityHistoryComplexMapping()
            : base(Generators.Guid)
        {
            var defaultEntityHistory = default(EntityHistoryComplex);
            var defaultEntityLog = default(EntityLog);

            base.Property(x => x.IsActive, m =>
            {
                m.NotNullable(true);
            });

            base.ManyToOne(x => x.FirstLog, m =>
            {
                m.Cascade(Cascade.All);
                m.Lazy(LazyRelation.NoLazy);
                m.Access(Accessor.Property);
                m.Column(MappingAssistant.GetForeignKeyColumn(() => defaultEntityHistory.FirstLog));
            });

            base.ManyToOne(x => x.LastLog, m =>
            {
                m.Cascade(Cascade.All);
                m.Lazy(LazyRelation.NoLazy);
                m.Access(Accessor.Property);
                m.Column(MappingAssistant.GetForeignKeyColumn(() => defaultEntityHistory.LastLog));
            });

            base.Bag(x => x.Logs, cm =>
            {
                cm.Inverse(true);
                cm.Access(Accessor.Field);
                cm.Cascade(Cascade.All | Cascade.DeleteOrphans);
                cm.Lazy(CollectionLazy.Lazy);
                cm.Key(km => km.Column(MappingAssistant.GetForeignKeyColumn(() => defaultEntityLog.EntityHistory)));
            }, m =>
            {
                m.OneToMany();
            });
        }
    }
}
