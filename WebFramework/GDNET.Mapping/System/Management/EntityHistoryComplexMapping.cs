using System;
using GDNET.Domain.Base.Management;
using GDNET.Mapping.Base;
using GDNET.Mapping.Common;
using GDNET.NHibernate.Mapping;
using NHibernate.Mapping.ByCode;

namespace GDNET.Mapping.System.Management
{
    public class EntityHistoryComplexMapping : AbstractEntityWithModificationHistoryTMapping<EntityHistoryComplex, Guid>, IEntityMapping
    {
        public EntityHistoryComplexMapping()
            : base(Generators.Guid)
        {
            var defaultEntityLog = default(EntityLog);

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
