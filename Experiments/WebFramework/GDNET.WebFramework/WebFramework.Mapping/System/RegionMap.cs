using NHibernate.Mapping.ByCode;
using WebFramework.Base.Mapping;
using WebFramework.Domain.System;
using WebFramework.Mapping.Base;

namespace WebFramework.Mapping.System
{
    public class RegionMap : EntityWithActiveMapping<Region, long>, INHibernateMapping
    {
        public RegionMap()
            : base(Generators.Native)
        {
            base.Property(e => e.Name);
            base.Property(e => e.Description);
            base.Property(e => e.Position);

            base.ManyToOne(e => e.LifeCycle, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Column(MappingConstants.StatutLifeCycleId);
                m.Cascade(Cascade.All);
            });

            base.ManyToOne(e => e.Widget, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Cascade(Cascade.None);
                m.Column(MappingConstants.WidgetId);
            });

            base.ManyToOne(e => e.Zone, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Cascade(Cascade.None);
                m.Column(MappingConstants.ZoneId);
            });

            base.Bag(e => e.Settings, cm =>
            {
                cm.Access(Accessor.Field);
                cm.Lazy(CollectionLazy.Lazy);
                cm.Key(k => k.Column(MappingConstants.RegionId));
                cm.Cascade(Cascade.All | Cascade.DeleteOrphans);
            }, m =>
            {
                m.OneToMany();
            });

            base.Bag(e => e.RegionConnections, cm =>
            {
                cm.Access(Accessor.Field);
                cm.Lazy(CollectionLazy.Lazy);
                cm.Key(k => k.Column(MappingConstants.RegionIdFrom));
                cm.Cascade(Cascade.All | Cascade.DeleteOrphans);
            }, m =>
            {
                m.OneToMany();
            });
        }
    }
}
