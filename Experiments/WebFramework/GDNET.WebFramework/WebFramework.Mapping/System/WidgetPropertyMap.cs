using NHibernate.Mapping.ByCode;
using WebFramework.Domain.System;
using WebFramework.Mapping.Base;

namespace WebFramework.Mapping.System
{
    public class WidgetPropertyMap : EntityBaseMapping<WidgetProperty, long>, INHibernateMapping
    {
        public WidgetPropertyMap()
            : base(Generators.Native)
        {
            base.Property(e => e.Code);
            base.Property(e => e.Value);
            base.Property(e => e.IsActive);

            base.ManyToOne(e => e.DataType, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Column(MappingConstants.DataTypeId);
                m.Cascade(Cascade.None);
            });

            base.ManyToOne(e => e.Widget, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Cascade(Cascade.None);
                m.Column(MappingConstants.WidgetId);
            });

            base.ManyToOne(e => e.LifeCycle, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Column(MappingConstants.StatutLifeCycleId);
                m.Cascade(Cascade.All);
            });
        }
    }
}
