using System;
using GDNET.Domain.Base.Management;
using GDNET.Mapping.Base;
using GDNET.Mapping.Common;
using GDNET.NHibernate.Mapping;
using NHibernate.Mapping.ByCode;

namespace GDNET.Mapping.System.Management
{
    public class EntityHistoryMapping : AbstractEntityWithModificationTMapping<EntityHistory, Guid>, IEntityMapping
    {
        public EntityHistoryMapping()
            : base(Generators.Guid)
        {
            var defaultEntityHistory = default(EntityHistory);
            var defaultEntityLog = default(EntityLog);

            base.ManyToOne(x => x.LastLog, m =>
            {
                m.Cascade(Cascade.All | Cascade.DeleteOrphans);
                m.Lazy(LazyRelation.NoLazy);
                m.Column(MappingAssistant.GetForeignKeyColumn(() => defaultEntityHistory.LastLog));
            });

            base.Bag(x => x.Logs, cm =>
            {
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
