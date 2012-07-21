using GDNET.Domain.Base;
using GDNET.Mapping.Common;
using NHibernate.Mapping.ByCode;

namespace GDNET.Mapping.Base
{
    public abstract class AbstractEntityWithModificationHistoryTMapping<TObject, TId> : AbstractEntityWithModificationTMapping<TObject, TId>
        where TObject : AbstractEntityWithModificationHistoryT<TId>
    {
        public AbstractEntityWithModificationHistoryTMapping(IGeneratorDef generator)
            : base(generator)
        {
            var defaultEntityHistory = default(AbstractEntityWithModificationHistoryT<TId>);

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
        }
    }
}
