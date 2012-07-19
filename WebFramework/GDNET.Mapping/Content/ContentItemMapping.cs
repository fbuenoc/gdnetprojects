using System;
using GDNET.Domain.Content;
using GDNET.Mapping.Base;
using GDNET.NHibernate.Mapping;

namespace GDNET.Mapping.Content
{
    public class ContentItemMapping : AbstractJoinedSubclassMapping<ContentItem, Guid>, IEntityMapping
    {
        public ContentItemMapping()
        {
            base.Property(e => e.Name, m => m.NotNullable(true));
            base.Property(e => e.Description);
            base.Property(e => e.Keywords);
        }
    }
}
