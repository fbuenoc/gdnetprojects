using NHibernate.Mapping.ByCode;
using WebFramework.Domain.Common;
using WebFramework.Mapping.Base;
using WebFramework.Mapping.Constants;

namespace WebFramework.Mapping.Common
{
    public class ContentTypeMap : AbstractEntityMappingWithModification<ContentType, long>, INHibernateMapping
    {
        public ContentTypeMap()
            : base(Generators.Native)
        {
            base.Property(e => e.TypeName);
            base.Property(e => e.Code);

            base.ManyToOne(e => e.LifeCycle, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Column(MappingConstants.StatutLifeCycleId);
                m.Cascade(Cascade.All);
            });
            base.ManyToOne(e => e.Name, m =>
            {
                m.Lazy(LazyRelation.NoLazy);
                m.Column(MappingConstants.NameTranslationId);
                m.Cascade(Cascade.All | Cascade.DeleteOrphans);
            });
            base.ManyToOne(e => e.Application, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Column(MappingConstants.ApplicationId);
                m.Cascade(Cascade.None);
            });

            base.Bag(e => e.ContentItems, cm =>
            {
                cm.Lazy(CollectionLazy.Lazy);
                cm.Access(Accessor.Field);
                cm.Key(k => k.Column(MappingConstants.ContentTypeId));
                cm.Cascade(Cascade.None);
            }, m =>
            {
                m.OneToMany();
            });

            base.Bag(e => e.ContentAttributes, cm =>
            {
                cm.Lazy(CollectionLazy.Lazy);
                cm.Access(Accessor.Field);
                cm.Key(k => k.Column(MappingConstants.ContentTypeId));
                cm.Cascade(Cascade.All | Cascade.DeleteOrphans);
                cm.Inverse(true);
            }, m =>
            {
                m.OneToMany();
            });

        }
    }
}
