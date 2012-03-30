using NHibernate.Mapping.ByCode;
using WebFramework.Domain.System;
using WebFramework.Mapping.Base;

namespace WebFramework.Mapping.System
{
    public class RegionConnectionMap : AbstractEntityMapping<RegionConnection, long>, INHibernateMapping
    {
        public RegionConnectionMap()
            : base(Generators.Native)
        {
            base.Property(e => e.Action);

            base.ManyToOne(e => e.From, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Cascade(Cascade.None);
                m.Column(MappingConstants.RegionIdFrom);
            });

            base.ManyToOne(e => e.To, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Cascade(Cascade.None);
                m.Column(MappingConstants.RegionIdTo);
            });
        }
    }
}
