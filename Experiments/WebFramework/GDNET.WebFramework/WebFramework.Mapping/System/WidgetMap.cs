using NHibernate.Mapping.ByCode;
using WebFramework.Domain.System;
using WebFramework.Mapping.Base;
using WebFramework.Mapping.Constants;

namespace WebFramework.Mapping.System
{
    public class WidgetMap : AbstractEntityMapping<Widget, long>, INHibernateMapping
    {
        public WidgetMap()
            : base(Generators.Native)
        {
            base.Property(e => e.Code);
            base.Property(e => e.ClassName);
            base.Property(e => e.AssemblyName);

            base.ManyToOne(e => e.Name, m =>
            {
                m.Lazy(LazyRelation.NoLazy);
                m.Cascade(Cascade.All | Cascade.DeleteOrphans);
                m.Column(MappingConstants.NameTranslationId);
            });
            base.ManyToOne(e => e.Description, m =>
            {
                m.Lazy(LazyRelation.NoLazy);
                m.Cascade(Cascade.All | Cascade.DeleteOrphans);
                m.Column(MappingConstants.DescriptionTranslationId);
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
