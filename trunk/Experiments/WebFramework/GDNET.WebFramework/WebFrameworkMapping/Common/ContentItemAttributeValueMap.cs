using NHibernate.Mapping.ByCode;

using WebFrameworkDomain.Common;
using WebFrameworkMapping.Base;

namespace WebFrameworkMapping.Common
{
    public class ContentItemAttributeValueMap : EntityMappingBase<ContentItemAttributeValue, long>
    {
        public ContentItemAttributeValueMap()
            : base(Generators.Native)
        {
            base.ManyToOne(e => e.ContentAttribute, m =>
            {
                m.NotNullable(true);
                m.Column(ContentItemAttributeValueMeta.ContentAttributeId);
                m.Cascade(Cascade.None);
            });
            base.ManyToOne(e => e.ContentItem, m =>
            {
                m.NotNullable(true);
                m.Column(ContentItemAttributeValueMeta.ContentItemId);
                m.Cascade(Cascade.None);
            });
            base.ManyToOne(e => e.Value, m =>
            {
                m.NotNullable(true);
                m.Column(ContentItemAttributeValueMeta.ValueTranslationId);
                m.Cascade(Cascade.All | Cascade.DeleteOrphans);
            });
        }
    }
}
