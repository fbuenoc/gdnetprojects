using System;
using GDNET.Domain.Base.Management;
using GDNET.NHibernate.Mapping;
using GDNET.Utils;
using NHibernate.Mapping.ByCode;

namespace GDNET.Data.Base.Management
{
    public class EntityHistoryMapping : AbstractEntityWithModificationTMapping<EntityHistory, Guid>, IEntityMapping
    {
        public EntityHistoryMapping()
            : base(Generators.Guid)
        {
            base.Bag(x => x.Logs, cm =>
            {
                cm.Access(Accessor.Field);
                cm.Cascade(Cascade.All | Cascade.DeleteOrphans);
                cm.Lazy(CollectionLazy.Lazy);
                cm.Key(km => km.Column(this.GetKeyForLogs()));
            }, m =>
            {
                m.OneToMany();
            });
        }

        private string GetKeyForLogs()
        {
            var defaultEntity = default(EntityLog);

            var id = ExpressionAssistant.GetPropertyName(() => defaultEntity.Id);
            var entityHistory = ExpressionAssistant.GetPropertyName(() => defaultEntity.EntityHistory);

            return (entityHistory + id);
        }

    }
}
