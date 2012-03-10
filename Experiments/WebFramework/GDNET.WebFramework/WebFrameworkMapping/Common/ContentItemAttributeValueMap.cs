using NHibernate.Mapping.ByCode;
using WebFramework.Domain.Common;
using WebFramework.Mapping.Base;
using WebFramework.Mapping.Constants;

namespace WebFramework.Mapping.Common
{
    public class ContentItemAttributeValueMap : AbstractEntityMapping<ContentItemAttributeValue, long>, INHibernateMapping
    {
        public ContentItemAttributeValueMap()
            : base(Generators.Native)
        {
            base.ManyToOne(e => e.ContentAttribute, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Column(MappingConstants.ContentItemAttributeValue.ContentAttributeId);
                m.Cascade(Cascade.None);
            });
            base.ManyToOne(e => e.ContentItem, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Column(MappingConstants.ContentItemId);
                m.Cascade(Cascade.None);
            });
            base.ManyToOne(e => e.Value, m =>
            {
                m.Lazy(LazyRelation.NoLazy);
                m.Column(MappingConstants.ContentItemAttributeValue.ValueTranslationId);
                m.Cascade(Cascade.All | Cascade.DeleteOrphans);
            });
        }
    }
}
