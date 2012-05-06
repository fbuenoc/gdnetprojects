using NHibernate.Mapping.ByCode;
using WebFramework.Domain.System;
using WebFramework.Mapping.Base;

namespace WebFramework.Mapping.System
{
    public class WidgetMap : EntityWithActiveMapping<Widget, long>, INHibernateMapping
    {
        public WidgetMap()
            : base(Generators.Native)
        {
            base.Property(e => e.Code);
            base.Property(e => e.TechnicalName);
            base.Property(e => e.Version);
            base.Property(e => e.ClassName);
            base.Property(e => e.AssemblyName);
            base.Property(e => e.RepositoryClassName);
            base.Property(e => e.RepositoryAssemblyName);

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

            base.Bag(e => e.Properties, cm =>
            {
                cm.Access(Accessor.Field);
                cm.Lazy(CollectionLazy.Lazy);
                cm.Key(k => k.Column(MappingConstants.WidgetId));
                cm.Cascade(Cascade.All | Cascade.DeleteOrphans);
            }, m =>
            {
                m.OneToMany();
            });
        }
    }
}
