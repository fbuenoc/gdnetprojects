using NHibernate.Mapping.ByCode;
using WebFrameworkDomain.Common;
using WebFrameworkMapping.Base;
using WebFrameworkMapping.Constants;

namespace WebFrameworkMapping.Common
{
    public class TranslationMap : AbstractEntityMappingWithModification<Translation, long>, INHibernateMapping
    {
        public TranslationMap()
            : base(Generators.Native)
        {
            base.Property(e => e.Code);
            base.Property(e => e.Value, m =>
            {
                m.Lazy(true);
            });

            base.ManyToOne(e => e.LifeCycle, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Column(MappingConstants.StatutLifeCycleId);
                m.Cascade(Cascade.All);
            });
            base.ManyToOne(e => e.Category, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Column(MappingConstants.Translation.CategoryId);
                m.Cascade(Cascade.None);
            });
            base.ManyToOne(e => e.Culture, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Column(MappingConstants.Translation.CultureId);
                m.Cascade(Cascade.None);
            });
        }
    }
}
