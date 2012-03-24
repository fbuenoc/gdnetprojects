using NHibernate.Mapping.ByCode;
using WebFramework.Domain.Common;
using WebFramework.Mapping.Base;

namespace WebFramework.Mapping.Common
{
    public class ContentItemMap : AbstractEntityWithModificationMapping<ContentItem, long>, INHibernateMapping
    {
        public ContentItemMap()
            : base(Generators.Native)
        {
            base.Property(e => e.Position);
            base.Property(e => e.Views);

            base.ManyToOne(e => e.LifeCycle, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Column(MappingConstants.StatutLifeCycleId);
                m.Cascade(Cascade.All);
            });
            base.ManyToOne(e => e.ContentType, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Column(MappingConstants.ContentTypeId);
                m.Cascade(Cascade.None);
            });
            base.ManyToOne(e => e.Name, m =>
            {
                m.Lazy(LazyRelation.NoLazy);
                m.Column(MappingConstants.NameTranslationId);
                m.Cascade(Cascade.All | Cascade.DeleteOrphans);
            });
            base.ManyToOne(e => e.Description, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Column(MappingConstants.DescriptionTranslationId);
                m.Cascade(Cascade.All | Cascade.DeleteOrphans);
            });

            base.Bag(e => e.RelationItems, cm =>
            {
                cm.Access(Accessor.Field);
                cm.Lazy(CollectionLazy.Lazy);
                cm.Table(MappingConstants.ContentItem.ContentItemRelationTable);
                cm.Key(k => k.Column(MappingConstants.ContentItemId));
                cm.Cascade(Cascade.None);
            }, m =>
            {
                m.ManyToMany(mm =>
                {
                    mm.Column(MappingConstants.ContentItem.RelationContentItemId);
                });
            });

            base.Bag(e => e.AttributeValues, cm =>
            {
                cm.Access(Accessor.Field);
                cm.Lazy(CollectionLazy.Lazy);
                cm.Key(k => k.Column(MappingConstants.ContentItemId));
                cm.Cascade(Cascade.All);
                cm.Inverse(true);
            }, m =>
            {
                m.OneToMany();
            });
        }
    }
}

