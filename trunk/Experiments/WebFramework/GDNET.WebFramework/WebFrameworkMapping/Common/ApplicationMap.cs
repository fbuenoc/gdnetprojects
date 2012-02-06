using NHibernate.Mapping.ByCode;
using WebFrameworkDomain.Common;
using WebFrameworkMapping.Base;

namespace WebFrameworkMapping.Common
{
    public class ApplicationMap : EntityFullControlMappingBase<Application, long>, INHibernateMapping
    {
        public ApplicationMap()
            : base(Generators.Native)
        {
            base.ManyToOne(e => e.Name, m =>
            {
                m.Lazy(LazyRelation.NoLazy);
                m.NotNullable(true);
                m.Cascade(Cascade.All | Cascade.DeleteOrphans);
                m.Column(ApplicationMeta.NameTranslationId);
            });
            base.ManyToOne(e => e.Description, m =>
            {
                m.Lazy(LazyRelation.NoLazy);
                m.NotNullable(true);
                m.Cascade(Cascade.All | Cascade.DeleteOrphans);
                m.Column(ApplicationMeta.DescriptionTranslationId);
            });
            base.ManyToOne(e => e.Category, m =>
            {
                m.NotNullable(true);
                m.Cascade(Cascade.None);
                m.Column(ApplicationMeta.CategoryId);
            });
            base.ManyToOne(e => e.CultureDefault, m =>
            {
                m.NotNullable(true);
                m.Cascade(Cascade.None);
                m.Column(ApplicationMeta.CultureDefaultId);
            });

            base.Property(e => e.RootUrl);
        }
    }
}
