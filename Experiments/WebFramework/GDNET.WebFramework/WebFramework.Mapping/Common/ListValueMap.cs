using NHibernate.Mapping.ByCode;
using WebFramework.Domain.Common;
using WebFramework.Mapping.Base;

namespace WebFramework.Mapping.Common
{
    public class ListValueMap : AbstractEntityWithModificationMapping<ListValue, long>, INHibernateMapping
    {
        public ListValueMap()
            : base(Generators.Native)
        {
            base.Property(e => e.Name);
            base.Property(e => e.CustomValue);
            base.Property(e => e.Position);

            base.ManyToOne(e => e.LifeCycle, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Column(MappingConstants.StatutLifeCycleId);
                m.Cascade(Cascade.All);
            });
            base.ManyToOne(e => e.Description, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Cascade(Cascade.All | Cascade.DeleteOrphans);
                m.Column(MappingConstants.DescriptionTranslationId);
            });
            base.ManyToOne(e => e.Detail, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Cascade(Cascade.All | Cascade.DeleteOrphans);
                m.Column(MappingConstants.DetailTranslationId);
            });
            base.ManyToOne(e => e.Application, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Cascade(Cascade.None);
                m.Column(MappingConstants.ApplicationId);
            });
            base.ManyToOne(e => e.Parent, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Cascade(Cascade.All | Cascade.DeleteOrphans);
                m.Column(MappingConstants.ListValue.ParentId);
            });

            base.Bag(e => e.SubValues, cm =>
            {
                cm.Access(Accessor.Field);
                cm.Lazy(CollectionLazy.Lazy);
                cm.Key(k => k.Column(MappingConstants.ListValue.ParentId));
                cm.Cascade(Cascade.All | Cascade.DeleteOrphans);
            }, m =>
            {
                m.OneToMany();
            });
        }
    }
}
