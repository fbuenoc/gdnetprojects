﻿using NHibernate.Mapping.ByCode;
using WebFramework.Base.Mapping;
using WebFramework.Domain.Common;
using WebFramework.Mapping.Base;

namespace WebFramework.Mapping.Common
{
    public class ContentItemAttributeValueMap : EntityBaseMapping<ContentItemAttributeValue, long>, INHibernateMapping
    {
        public ContentItemAttributeValueMap()
            : base(Generators.Native)
        {
            base.Property(e => e.ValueText);

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
            base.ManyToOne(e => e.ValueTranslation, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Column(MappingConstants.ContentItemAttributeValue.ValueTranslationId);
                m.Cascade(Cascade.All | Cascade.DeleteOrphans);
            });
        }
    }
}
