using NHibernate.Mapping.ByCode;
using WebFramework.Base.Mapping;
using WebFramework.Domain.Common;
using WebFramework.Mapping.Base;

namespace WebFramework.Mapping.Common
{
    public class StatutLifeCycleMap : EntityBaseMapping<StatutLifeCycle, long>, INHibernateMapping
    {
        public StatutLifeCycleMap()
            : base(Generators.Native)
        {
            base.Bag(e => e.StatutLogs, cm =>
            {
                cm.Lazy(CollectionLazy.Lazy);
                cm.Access(Accessor.Field);
                cm.Key(k => k.Column(MappingConstants.StatutLifeCycleId));
                cm.Cascade(Cascade.All | Cascade.DeleteOrphans);
                cm.Inverse(true);
            }, m =>
            {
                m.OneToMany();
            });

            base.ManyToOne(e => e.ActualStatut, cm =>
            {
                cm.Lazy(LazyRelation.NoLazy);
                cm.Cascade(Cascade.None);
                cm.Column(MappingConstants.StatutLifeCycle.ActualStatutId);
            });
        }
    }
}
