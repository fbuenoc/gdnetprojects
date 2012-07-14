using GDNET.Domain.Base;
using GDNET.Utils;
using NHibernate.Mapping.ByCode;

namespace GDNET.Data.Base
{
    public abstract class AbstractEntityWithModificationHistoryTMapping<TObject, TId> : AbstractEntityWithModificationTMapping<TObject, TId>
        where TObject : AbstractEntityWithModificationHistoryT<TId>
    {
        public AbstractEntityWithModificationHistoryTMapping(IGeneratorDef generator)
            : base(generator)
        {
            base.ManyToOne(e => e.History, m =>
            {
                m.Cascade(Cascade.All | Cascade.DeleteOrphans);
                m.Lazy(LazyRelation.Proxy);
                m.Access(Accessor.Field);
                m.Column(this.GetColumnForHistory());
            });
        }

        private string GetColumnForHistory()
        {
            var defaultEntity = default(AbstractEntityWithModificationHistoryT<TId>);

            var id = ExpressionAssistant.GetPropertyName(() => defaultEntity.Id);
            var history = ExpressionAssistant.GetPropertyName(() => defaultEntity.History);

            return (history + id);
        }
    }
}
