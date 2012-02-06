using NHibernate.Mapping.ByCode;
using WebFrameworkDomain.Common;
using WebFrameworkMapping.Base;

namespace WebFrameworkMapping.Common
{
    public class ContentAttributeMap : EntityFullControlMappingBase<ContentAttribute, long>, INHibernateMapping
    {
        public ContentAttributeMap()
            : base(Generators.Native)
        {
            base.Property(e => e.Code);
            base.Property(e => e.Position);

            base.ManyToOne(e => e.ContentType, m =>
            {
                m.NotNullable(true);
                m.Column(ContentAttributeMeta.ContentTypeId);
                m.Cascade(Cascade.None);
            });
            base.ManyToOne(e => e.DataType, m =>
            {
                m.NotNullable(true);
                m.Column(ContentAttributeMeta.DataTypeId);
                m.Cascade(Cascade.None);
            });

            base.Bag(e => e.ContentItems, cm =>
            {
                cm.Access(Accessor.Field);
                cm.Lazy(CollectionLazy.Lazy);
                cm.Table(ContentItemAttributeValueMeta.ContentItemAttributeValue);
                cm.Key(k => k.Column(ContentItemAttributeValueMeta.ContentAttributeId));
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
                cm.Table(ContentItemAttributeValueMeta.ContentItemAttributeValue);
                cm.Key(k => k.Column(ContentItemAttributeValueMeta.ContentAttributeId));
                cm.Cascade(Cascade.None);
                cm.Inverse(true);
            }, m =>
            {
                m.OneToMany();
            });
        }
    }
}
