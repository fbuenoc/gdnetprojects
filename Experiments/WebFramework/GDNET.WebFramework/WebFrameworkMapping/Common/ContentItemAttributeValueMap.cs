using NHibernate.Mapping.ByCode;
using WebFrameworkDomain.Common;
using WebFrameworkMapping.Base;
using WebFrameworkMapping.Constants;

namespace WebFrameworkMapping.Common
{
    public class ContentItemAttributeValueMap : AbstractEntityMapping<ContentItemAttributeValue, long>, INHibernateMapping
    {
        public ContentItemAttributeValueMap()
            : base(Generators.Native)
        {
            base.ManyToOne(e => e.ContentAttribute, m =>
            {
                m.Column(MappingConstants.ContentItemAttributeValue.ContentAttributeId);
                m.Cascade(Cascade.None);
            });
            base.ManyToOne(e => e.ContentItem, m =>
            {
                m.Column(MappingConstants.ContentItemId);
                m.Cascade(Cascade.None);
            });
            base.ManyToOne(e => e.Value, m =>
            {
                m.Column(MappingConstants.ContentItemAttributeValue.ValueTranslationId);
                m.Cascade(Cascade.All | Cascade.DeleteOrphans);
            });
        }
    }
}
