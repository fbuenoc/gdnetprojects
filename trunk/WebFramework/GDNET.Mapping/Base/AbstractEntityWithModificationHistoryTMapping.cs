using GDNET.Domain.Entities.System.Management;
using GDNET.Mapping.Common;
using NHibernate.Mapping.ByCode;

namespace GDNET.Mapping.Base
{
    public abstract class AbstractEntityWithModificationHistoryTMapping<TObject, TId> : AbstractEntityWithModificationTMapping<TObject, TId>
        where TObject : AbstractEntityWithModificationHistoryT<TId>
    {
        private static readonly AbstractEntityWithModificationHistoryT<TId> _defaultEntity = default(AbstractEntityWithModificationHistoryT<TId>);

        public AbstractEntityWithModificationHistoryTMapping(IGeneratorDef generator)
            : base(generator)
        {
            base.Property(x => x.IsActive);
            base.Property(x => x.Views);

            base.ManyToOne(x => x.FirstLog, m =>
            {
                m.Cascade(Cascade.All);
                m.Lazy(LazyRelation.NoLazy);
                m.Access(Accessor.Property);
                m.Column(MappingAssistant.GetForeignKeyColumn(() => _defaultEntity.FirstLog));
            });

            base.ManyToOne(x => x.LastLog, m =>
            {
                m.Cascade(Cascade.All);
                m.Lazy(LazyRelation.NoLazy);
                m.Access(Accessor.Property);
                m.Column(MappingAssistant.GetForeignKeyColumn(() => _defaultEntity.LastLog));
            });
        }
    }
}
