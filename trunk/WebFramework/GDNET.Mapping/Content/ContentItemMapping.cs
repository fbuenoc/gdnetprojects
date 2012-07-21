using System;
using GDNET.Domain.Content;
using GDNET.Mapping.Base;
using GDNET.Mapping.Common;
using GDNET.NHibernate.Mapping;
using NHibernate.Mapping.ByCode;

namespace GDNET.Mapping.Content
{
    public class ContentItemMapping : AbstractJoinedSubclassMapping<ContentItem, Guid>, IEntityMapping
    {
        public ContentItemMapping()
        {
            var defaultContentPart = default(ContentPart);

            base.Property(e => e.Name, m => m.NotNullable(true));
            base.Property(e => e.Description);
            base.Property(e => e.Keywords);

            base.Bag(e => e.Parts, cm =>
            {
                cm.Inverse(true);
                cm.Access(Accessor.Field);
                cm.Cascade(Cascade.All | Cascade.DeleteOrphans);
                cm.Lazy(CollectionLazy.Lazy);
                cm.Key(km => km.Column(MappingAssistant.GetForeignKeyColumn(() => defaultContentPart.ContentItem)));
            }, m =>
            {
                m.OneToMany();
            });
        }
    }
}
