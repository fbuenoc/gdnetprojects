using NHibernate.Mapping.ByCode;
using WebFramework.Domain.Common;
using WebFramework.Mapping.Base;

namespace WebFramework.Mapping.Common
{
    public class TranslationMap : EntityWithModificationMapping<Translation, long>, INHibernateMapping
    {
        public TranslationMap()
            : base(Generators.Native)
        {
            base.Lazy(false);

            base.Property(e => e.Code);
            base.Property(e => e.Value);
            base.Property(e => e.IsRichTextEditor);

            base.ManyToOne(e => e.LifeCycle, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Column(MappingConstants.StatutLifeCycleId);
                m.Cascade(Cascade.All);
            });
            base.ManyToOne(e => e.Category, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Column(MappingConstants.CategoryId);
                m.Cascade(Cascade.None);
            });
            base.ManyToOne(e => e.Culture, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Column(MappingConstants.CultureId);
                m.Cascade(Cascade.None);
            });
        }
    }
}
