using NHibernate.Mapping.ByCode;
using WebFramework.Domain.Common;
using WebFramework.Mapping.Base;

namespace WebFramework.Mapping.Common
{
    public class ApplicationMap : AbstractEntityWithModificationMapping<Application, long>, INHibernateMapping
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
                m.Lazy(LazyRelation.Proxy);
                m.Cascade(Cascade.None);
                m.Column(MappingConstants.CategoryId);
            });
            base.ManyToOne(e => e.CultureDefault, m =>
            {
                m.Lazy(LazyRelation.Proxy);
                m.Cascade(Cascade.None);
                m.Column(MappingConstants.Application.CultureDefaultId);
            });
        }
    }
}
