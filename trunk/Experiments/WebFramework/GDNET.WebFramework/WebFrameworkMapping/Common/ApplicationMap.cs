using NHibernate.Mapping.ByCode;
using WebFrameworkDomain.Common;
using WebFrameworkMapping.Base;
using WebFrameworkMapping.Constants;

namespace WebFrameworkMapping.Common
{
    public class ApplicationMap : AbstractEntityMappingWithModification<Application, long>, INHibernateMapping
    {
        public ApplicationMap()
            : base(Generators.Native)
        {
            base.Property(e => e.RootUrl);

            base.ManyToOne(e => e.LifeCycle, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Column(MappingConstants.StatutLifeCycleId);
                m.Cascade(Cascade.All);
            });
            base.ManyToOne(e => e.Name, m =>
            {
                m.Lazy(LazyRelation.NoLazy);
                m.Cascade(Cascade.All | Cascade.DeleteOrphans);
                m.Column(MappingConstants.NameTranslationId);
            });
            base.ManyToOne(e => e.Description, m =>
            {
                m.Lazy(LazyRelation.NoLazy);
                m.Cascade(Cascade.All | Cascade.DeleteOrphans);
                m.Column(MappingConstants.DescriptionTranslationId);
            });
            base.ManyToOne(e => e.Category, m =>
            {
                m.Cascade(Cascade.None);
                m.Column(MappingConstants.Application.CategoryId);
            });
            base.ManyToOne(e => e.CultureDefault, m =>
            {
                m.Cascade(Cascade.None);
                m.Column(MappingConstants.Application.CultureDefaultId);
            });
        }
    }
}
