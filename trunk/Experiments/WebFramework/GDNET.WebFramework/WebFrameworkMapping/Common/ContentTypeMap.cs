using NHibernate.Mapping.ByCode;

using WebFrameworkDomain.Common;
using WebFrameworkMapping.Base;

namespace WebFrameworkMapping.Common
{
    public class ContentTypeMap : EntityFullControlMappingBase<ContentType, long>
    {
        public ContentTypeMap()
            : base(Generators.Native)
        {
            base.ManyToOne(e => e.Name, m =>
            {
                m.NotNullable(true);
                m.Column(ContentTypeMeta.NameTranslationId);
                m.Cascade(Cascade.All | Cascade.DeleteOrphans);
            });
            base.ManyToOne(e => e.Application, m =>
            {
                m.NotNullable(false);
                m.Column(ContentTypeMeta.ApplicationId);
                m.Cascade(Cascade.None);
            });

            base.Bag(e => e.ContentItems, cm =>
            {
                cm.Lazy(CollectionLazy.Lazy);
                cm.Access(Accessor.Field);
                cm.Key(k => k.Column(ContentItemMeta.ContentTypeId));
                cm.Cascade(Cascade.None);
            }, m =>
            {
                m.OneToMany();
            });

            base.Property(e => e.TypeName);
        }
    }
}
