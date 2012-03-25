using NHibernate.Mapping.ByCode;
using WebFramework.Domain.System;
using WebFramework.Mapping.Base;

namespace WebFramework.Mapping.System
{
    public class PageMap : AbstractEntityWithActiveMapping<Page, long>, INHibernateMapping
    {
        public PageMap()
            : base(Generators.Native)
        {
            base.Property(e => e.Name);
            base.Property(e => e.UniqueName);
            base.Property(e => e.Description);
            base.Property(e => e.Keyword);
            base.Property(e => e.Position);

            base.ManyToOne(e => e.LifeCycle, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Column(MappingConstants.StatutLifeCycleId);
                m.Cascade(Cascade.All);
            });

            base.ManyToOne(e => e.Application, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Cascade(Cascade.None);
                m.Column(MappingConstants.ApplicationId);
            });

            base.ManyToOne(e => e.Culture, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Cascade(Cascade.None);
                m.Column(MappingConstants.CultureId);
            });

            base.Bag(e => e.Zones, cm =>
            {
                cm.Access(Accessor.Field);
                cm.Lazy(CollectionLazy.Lazy);
                cm.Key(k => k.Column(MappingConstants.PageId));
                cm.Cascade(Cascade.All | Cascade.DeleteOrphans);
            }, m =>
            {
                m.OneToMany();
            });
        }
    }
}
