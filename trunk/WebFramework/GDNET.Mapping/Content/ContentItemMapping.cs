using System;
using GDNET.Domain.Content;
using GDNET.Mapping.Base;
using GDNET.Mapping.Common;
using GDNET.NHibernate.Mapping;
using GDNET.Utils;
using NHibernate.Mapping.ByCode;

namespace GDNET.Mapping.Content
{
    public class ContentItemMapping : AbstractJoinedSubclassMapping<ContentItem, Guid>, IEntityMapping
    {
        public ContentItemMapping()
            : base()
        {
            var defaultContentPart = default(ContentPart);

            base.Property(e => e.Name, m => m.NotNullable(true));
            base.Property(e => e.Description);
            base.Property(e => e.Keywords);

            base.List(e => e.Parts, cm =>
            {
                cm.Access(Accessor.Field);
                cm.Cascade(Cascade.All | Cascade.DeleteOrphans);
                cm.Lazy(CollectionLazy.Lazy);
                cm.Key(km => km.Column(MappingAssistant.GetForeignKeyColumn(() => defaultContentPart.ContentItem)));
                cm.Index(idx =>
                {
                    idx.Base(1);
                    idx.Column(ExpressionAssistant.GetPropertyName(() => defaultContentPart.Position));
                });
            }, m =>
            {
                m.OneToMany(mapping => mapping.NotFound(NotFoundMode.Exception));
            });
        }
    }
}
