using NHibernate.Mapping.ByCode;
using WebFrameworkDomain.Common;
using WebFrameworkMapping.Base;
using WebFrameworkMapping.Constants;

namespace WebFrameworkMapping.Common
{
    public class StatutLifeCycleMap : AbstractEntityMapping<StatutLifeCycle, long>, INHibernateMapping
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
                cm.Lazy(LazyRelation.Proxy);
                cm.Cascade(Cascade.None);
                cm.Column(MappingConstants.StatutLifeCycle.ActualStatutId);
            });
        }
    }
}
