using NHibernate.Mapping.ByCode;
using WebFramework.Base.Mapping;
using WebFramework.Domain.System;
using WebFramework.Mapping.Base;

namespace WebFramework.Mapping.System
{
    public class RegionSettingMap : EntityBaseMapping<RegionSetting, long>, INHibernateMapping
    {
        public RegionSettingMap()
            : base(Generators.Native)
        {
            base.Property(e => e.Value);

            base.ManyToOne(e => e.WidgetProperty, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Cascade(Cascade.None);
                m.Column(MappingConstants.WidgetPropertyId);
            });

            base.ManyToOne(e => e.Region, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Cascade(Cascade.None);
                m.Column(MappingConstants.RegionId);
            });
        }
    }
}
