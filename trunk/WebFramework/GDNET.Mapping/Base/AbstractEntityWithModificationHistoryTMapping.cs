using GDNET.Domain.Base;
using GDNET.Mapping.Common;
using NHibernate.Mapping.ByCode;

namespace GDNET.Mapping.Base
{
    public abstract class AbstractEntityWithModificationHistoryTMapping<TObject, TId> : AbstractEntityTMapping<TObject, TId>
        where TObject : AbstractEntityWithModificationHistoryT<TId>
    {
        public AbstractEntityWithModificationHistoryTMapping(IGeneratorDef generator)
            : base(generator)
        {
            var defaultEntity = default(AbstractEntityWithModificationHistoryT<TId>);

            base.ManyToOne(e => e.EntityHistory, m =>
            {
                m.Cascade(Cascade.All | Cascade.DeleteOrphans);
                m.Lazy(LazyRelation.Proxy);
                m.Access(Accessor.Field);
                m.Column(MappingAssistant.GetForeignKeyColumn(() => defaultEntity.EntityHistory));
            });
        }
    }
}
