using NHibernate.Mapping.ByCode;
using WebFrameworkDomain.Common;
using WebFrameworkMapping.Base;
using WebFrameworkMapping.Constants;

namespace WebFrameworkMapping.Common
{
    public class ContentAttributeMap : AbstractEntityMappingWithModification<ContentAttribute, long>, INHibernateMapping
    {
        public ContentAttributeMap()
            : base(Generators.Native)
        {
            base.Property(e => e.Code);
            base.Property(e => e.Position);
            base.Property(e => e.IsMultilingual);

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
            base.ManyToOne(e => e.DataType, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Column(MappingConstants.ContentAttribute.DataTypeId);
                m.Cascade(Cascade.None);
            });
            base.ManyToOne(e => e.Name, m =>
            {
                m.Lazy(LazyRelation.NoLazy);
                m.Column(MappingConstants.NameTranslationId);
                m.Cascade(Cascade.All);
            });

            base.Bag(e => e.ContentItems, cm =>
            {
                cm.Access(Accessor.Field);
                cm.Lazy(CollectionLazy.Lazy);
                cm.Table(MappingConstants.ContentItemAttributeValue.ContentItemAttributeValueTable);
                cm.Key(k => k.Column(MappingConstants.ContentItemAttributeValue.ContentAttributeId));
                cm.Cascade(Cascade.None);
                cm.Inverse(true);
            }, m =>
            {
                m.ManyToMany();
            });

            base.Bag(e => e.AttributeValues, cm =>
            {
                cm.Access(Accessor.Field);
                cm.Lazy(CollectionLazy.Lazy);
                cm.Key(k => k.Column(MappingConstants.ContentItemAttributeValue.ContentAttributeId));
                cm.Cascade(Cascade.None);
                cm.Inverse(true);
            }, m =>
            {
                m.OneToMany();
            });
        }
    }
}
