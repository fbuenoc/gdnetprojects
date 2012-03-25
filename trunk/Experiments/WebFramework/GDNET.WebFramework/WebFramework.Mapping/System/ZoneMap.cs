using NHibernate.Mapping.ByCode;
using WebFramework.Domain.System;
using WebFramework.Mapping.Base;

namespace WebFramework.Mapping.System
{
    public class ZoneMap : AbstractEntityWithActiveMapping<Zone, long>, INHibernateMapping
    {
        public ZoneMap()
            : base(Generators.Native)
        {
            base.Property(e => e.Code);
            base.Property(e => e.Description);

            base.ManyToOne(e => e.LifeCycle, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Column(MappingConstants.StatutLifeCycleId);
                m.Cascade(Cascade.All);
            });

            base.ManyToOne(e => e.Page, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Cascade(Cascade.None);
                m.Column(MappingConstants.PageId);
            });
        }
    }
}
