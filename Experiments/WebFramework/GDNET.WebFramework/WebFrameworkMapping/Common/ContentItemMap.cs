using NHibernate.Mapping.ByCode;

using WebFrameworkDomain.Common;
using WebFrameworkMapping.Base;
using GDNET.Extensions;

namespace WebFrameworkMapping.Common
{
    public class ContentItemMap : EntityFullControlMappingBase<ContentItem, long>
    {
        public ContentItemMap()
            : base(Generators.Native)
        {
            base.Property(e => e.Position);

            base.ManyToOne(e => e.ContentType, m =>
            {
                m.NotNullable(true);
                m.Column(ContentItemMeta.ContentTypeId);
                m.Cascade(Cascade.None);
            });
            base.ManyToOne(e => e.Name, m =>
            {
                m.NotNullable(true);
                m.Column(ContentItemMeta.NameTranslationId);
                m.Cascade(Cascade.All | Cascade.DeleteOrphans);
            });
            base.ManyToOne(e => e.Description, m =>
            {
                m.NotNullable(true);
                m.Column(ContentItemMeta.DescriptionTranslationId);
                m.Cascade(Cascade.All | Cascade.DeleteOrphans);
            });

            base.Bag(e => e.AttributeValues, cm =>
            {
                cm.Access(Accessor.Field);
                cm.Lazy(CollectionLazy.Lazy);
                cm.Table(ContentItemAttributeValueMeta.ContentItemAttributeValue);
                cm.Key(k => k.Column(ContentItemAttributeValueMeta.ContentItemId));
                cm.Cascade(Cascade.All);
                cm.Inverse(true);
            }, m =>
            {
                m.ManyToMany(mm =>
                {
                    mm.Column("Id");
                });
            });
        }
    }
}
